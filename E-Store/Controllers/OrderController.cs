namespace E_Store.Controllers
{
    using System.IO;
    using System;
    using System.Threading.Tasks;
    using System.Linq;
    using E_Store.Data.Models;
    using Business.Interfaces;
    using Models.Order;
    using Classes;
    using Extensions;
    using AutoMapper;
    using Models.Person;
    using E_Store.Business.Classes;
    using Newtonsoft.Json;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    using Microsoft.AspNetCore.Mvc.Razor;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc.Abstractions;
    using Microsoft.AspNetCore.Routing;
    using Microsoft.AspNetCore.Mvc.ModelBinding;


    public class OrderController : Controller
    {
        private readonly IOrderManager orderManager;
        private readonly IMapper mapper;
        private readonly IPersonManager personManager;
        private readonly IReadOnlyManager readonlyManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IAccountingSettingManager accountingSettingManager;
        private readonly IRazorViewEngine razorViewEngine;
        private readonly ITempDataProvider tempDataProvider;
        
        public OrderController(IOrderManager orderManager, 
            IMapper mapper,
            IPersonManager personManager,
            IReadOnlyManager readonlyManager,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IAccountingSettingManager accountingSettingManager,
            IRazorViewEngine razorViewEngine,
            ITempDataProvider tempDataProvider)
        {
            this.orderManager = orderManager;
            this.mapper = mapper;
            this.personManager = personManager;
            this.readonlyManager = readonlyManager;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.accountingSettingManager = accountingSettingManager;
            this.razorViewEngine = razorViewEngine;
            this.tempDataProvider = tempDataProvider;
        }
        
        [HttpGet]
        public IActionResult Index()
        {
            var model = new OrderIndexViewModel
            {
                OrderItems = this.orderManager.GetProducts().ToList(),
                OrderSummary = this.orderManager.GetOrderSummary()
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(OrderIndexViewModel model)
        {
            this.orderManager.UpdateCart(HttpContext.Request.Form);

            model.OrderItems = this.orderManager.GetProducts().ToList();
            model.OrderSummary = this.orderManager.GetOrderSummary();

            return View(model);
        }

        [HttpGet]
        public IActionResult RegisterOrder()
        {
            var model = new PersonRegisterViewModel();
            var order = this.orderManager.GetOrder();

            if (order.BuyerId.HasValue)
                model = this.mapper
                    .Map<PersonRegisterViewModel>(GetPersonDataForEdit(order.BuyerId.Value));

            model.Countries = 
                new SelectList(this.readonlyManager.GetAllCountries(), "Id", "Title");

            return View(model);
        }

        [HttpPost]
        public IActionResult RegisterOrder(PersonRegisterViewModel model, bool createAccount = false)
        {
            if (!createAccount)
            {
                ModelState.Remove("Password");
                ModelState.Remove("PasswordRepeat");
            }

            if (!ModelState.IsValid)
            {
                model.Countries =
                    new SelectList(this.readonlyManager.GetAllCountries(), "Id", "Title");

                return View(model);
            }

            var person = InsertOrEditPerson(model);
            this.orderManager.SetPerson(person);

            if (!createAccount)
                return RedirectToAction("Payment");

            if (this.userManager.FindByEmailAsync(model.Email) != null)
            {
                this.AddFlashMessage(
                    new FlashMessage($"The email {model.Email} is already in use", FlashMessageType.Danger));

                return RedirectToAction("RegisterOrder");
            }

            var user =
                new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    Id = person.UserId
                };

            var result = this.userManager.CreateAsync(user, model.Password).Result;

            if (result.Succeeded)
            {
                person.User = user;
                this.personManager.InsertOrEdit(person);
                this.userManager.AddToRoleAsync(user, "User");
                this.signInManager.SignInAsync(user, true);

                return RedirectToAction("Payment");
            }
            else
            {
                var allErrors = result.Errors
                    .Aggregate("The registration failed \n", (current, e) 
                        => current + (e.Description + " \n"));
                
                this.AddFlashMessage(allErrors, FlashMessageType.Danger);
                return RedirectToAction("RegisterOrder");
            }
        }
        
        [HttpGet]
        public async Task<IActionResult> Payment()
        {
            var order = this.orderManager.GetOrder();

            if (User.Identity is {IsAuthenticated: true})
            {
                var currentUser = await this.userManager.FindByNameAsync(User.Identity.Name);
                this.orderManager.SetPerson(currentUser.Person);
            }
            else if (order.BuyerId == null)
            {
                return RedirectToAction("RegisterOrder");
            }

            var model = new OrderPaymentViewModel
            {
                PaymentMethods = new SelectList(this.orderManager.GetPaymentMethods(), "Key", "Value")
            };

            return View(model);
        }

        [HttpGet]
        public IActionResult Summary()
        {
            var order = this.orderManager.GetOrder(create: false);

            if (order.Buyer == null)
                return Redirect("~/Order/RegisterOrder");

            if (order.DeliveryProduct == null)
                return Redirect("~/Order/Payment");

            var deliveryProductPrice = (int) Math.Round(order.DeliveryProduct.Price *
                                                        this.accountingSettingManager.GetCurrentTaxCoefficient());

            var orderItems = this.orderManager.GetProducts().ToList();
            
            orderItems.Add(new OrderItemInfo()
            {
                ProductId = order.DeliveryProduct.Id,
                Title = order.DeliveryProduct.Title,
                Price = deliveryProductPrice,
                Quantity = 1
            });

            var model = new OrderSummaryViewModel
            {
                OrderItems = orderItems,
                Person = order.Buyer,
                Registered = order.Buyer.User != null,
                DeliveryAddress = order.Buyer.DeliveryAddress
            };

            var orderSummary = orderManager.GetOrderSummary();

            orderSummary.Price += deliveryProductPrice;
            model.Summary = orderSummary;
            model.OrderId = order.Id;
            HttpContext.Session.SetString("SummaryViewModel", JsonConvert.SerializeObject(model));

            return View(model);
        }

        [HttpPost]
        public IActionResult Summary(int? orderId)
        {
            var model = JsonConvert.DeserializeObject<OrderSummaryViewModel>(
                HttpContext.Session.GetString("SummaryViewModel"));
            
            this.orderManager.CompleteOrder(ViewToString("_SummaryBodyPartial", model));
            this.AddFlashMessage(new FlashMessage("Thank you for the purchase, an order, an order confirmation has been sent to your email address.", FlashMessageType.Success));

            return Redirect("/Home/Index");

        }

        private string ViewToString(string viewName, object model)
        {
            var actionContext = new ActionContext(HttpContext, new RouteData(), new ActionDescriptor());

            using var sw = new StringWriter();
            var viewResult = this.razorViewEngine.FindView(actionContext, viewName, false);

            if (viewResult.View == null)
                throw new ArgumentNullException($"Unable to find the view named {viewName}");

            var viewDictionary =
                new ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary())
                {
                    Model = model
                };

            var viewContext = new ViewContext(
                actionContext,
                viewResult.View,
                viewDictionary,
                new TempDataDictionary(actionContext.HttpContext, tempDataProvider),
                sw,
                new HtmlHelperOptions()
            );

            viewResult.View.RenderAsync(viewContext).Wait();

            return sw.ToString();
        }
        
        [HttpPost]
        public IActionResult Payment(int deliveryProductId)
        {
            this.orderManager.SetDeliveryProduct(deliveryProductId);
            return RedirectToAction("Summary");
        }
        private Person InsertOrEditPerson(BasePersonViewModel personViewModel, string userId = null)
        {
            var personDetail = this.mapper.Map<PersonDetail>(personViewModel);
            var address = this.mapper.Map<Address>(personViewModel);
            var bankAccount = this.mapper.Map<BankAccount>(personViewModel);

            var deliveryAddress = new Address()
            {
                City = personViewModel.CityDelivery,
                CountryId = personViewModel.CountryIdDelivery,
                OrientationNumber = personViewModel.OrientationNumberDelivery,
                RegistryNumber = personViewModel.RegistryNumberDelivery ?? -1,
                Street = personViewModel.StreetDelivery,
                Zip = personViewModel.ZipDelivery
            };

            return this.personManager
                .InsertOrEdit(personDetail, address, deliveryAddress, bankAccount,
                    personViewModel.DeliveryAddressIsAddress, userId: userId);
        }
        private PersonEditViewModel GetPersonDataForEdit(int personId)
        {
            var person = this.personManager.FindById(personId);
            var model = this.mapper.Map<PersonEditViewModel>(person.PersonDetail);
            this.mapper.Map(person.Address, model);

            if (person.BankAccount != null)
                this.mapper.Map(person.BankAccount, model);

            if (person.AddressId != person.DeliveryAddressId)
            {
                model.DeliveryAddressIsAddress = false;
                model.CityDelivery = person.DeliveryAddress.City;
                model.CountryIdDelivery = person.DeliveryAddress.CountryId;
                model.OrientationNumberDelivery = person.DeliveryAddress.OrientationNumber;
                model.RegistryNumber = person.DeliveryAddress.RegistryNumber;
                model.StreetDelivery = person.DeliveryAddress.Street;
                model.ZipDelivery = person.DeliveryAddress.Zip;
            }
            else
            {
                model.DeliveryAddressIsAddress = true;
            }

            return model;

        }
    }
}