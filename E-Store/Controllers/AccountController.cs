namespace E_Store.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    
    using Models.User;
    using Classes;
    using Extensions;
    using Models.Person;
    using E_Store.Data.Models;
    using Business.Interfaces;
    using AutoMapper;
    
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    [Authorize]
    [Route("[controller]/[action]")]
    [ExceptionsToMessageFilter]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IReadOnlyManager readOnlyManager;
        private readonly IMapper mapper;
        private readonly IPersonManager personManager;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IReadOnlyManager readOnlyManager,
            IMapper mapper)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.readOnlyManager = readOnlyManager;
            this.mapper = mapper;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await signInManager
                .PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

            if (!result.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Invalid credentials");
                return View(model);
            }

            this.AddFlashMessage("Login successful.", FlashMessageType.Success);
            return RedirectToLocal(returnUrl);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Logout()
        {
            await this.signInManager.SignOutAsync();
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register(string returnUrl = null)
        {
            var model = new PersonRegisterViewModel
            {
                Countries = new SelectList(this.readOnlyManager.GetAllCountries(), "Id", "Title")
            };
            
            ViewData["ReturnUrl"] = returnUrl;
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(PersonRegisterViewModel model, string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                var userEmail = await this.userManager.FindByEmailAsync(model.Email);

                if (userEmail == null)
                {
                    var user = new ApplicationUser {UserName = model.Email, Email = model.Email};
                    var result = await this.userManager.CreateAsync(user, model.Password);

                    if (result.Succeeded)
                    {
                        var person = InsertOrEditPerson(model, user.Id);
                        await this.signInManager.SignInAsync(user, false);

                        return string.IsNullOrEmpty(returnUrl)
                            ? RedirectToAction("Index", "Home")
                            : RedirectToLocal(returnUrl);
                    }
                    AddErrors(result);
                }
                AddErrors(IdentityResult.Failed(new IdentityError() { Description = $"Email {model.Email} is already taken."}));
            }

            model.Countries = new SelectList(this.readOnlyManager.GetAllCountries(), "Id", "Title");
            ViewData["ReturnUrl"] = returnUrl;
            return View(model);
        }
        private object InsertOrEditPerson(BasePersonViewModel model, string userId = null, int? personId = null)
        {
            var personDetail = this.mapper.Map<PersonDetail>(model);
            var address = this.mapper.Map<Address>(model);
            var bankAccount = this.mapper.Map<BankAccount>(model);

            var addressDelivery = new Address()
            {
                City = model.CityDelivery,
                CountryId = model.CountryIdDelivery,
                OrientationNumber = model.OrientationNumberDelivery,
                RegistryNumber = model.RegistryNumberDelivery ?? -1,
                Street = model.StreetDelivery,
                Zip = model.ZipDelivery
            };

            address.Country ??= this.readOnlyManager.GetAllCountries()
                .Find(c => c.Id == model.AddressCountryId);

            addressDelivery.Country ??= this.readOnlyManager.GetAllCountries()
                .Find(c => c.Id == model.CountryIdDelivery);

            return this.personManager.InsertOrEdit(personDetail, address, addressDelivery, 
                bankAccount, model.DeliveryAddressIsAddress, personId, userId);
        }

        [HttpGet]
        public async Task<IActionResult> ChangePassword()
        {
            var user = await this.userManager.GetUserAsync(this.User)
                       ?? throw new ApplicationException(
                           $"Unable to load the user with ID '{userManager.GetUserId(this.User)}'");

            var model = new ChangePasswordViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            
            var user = await this.userManager.GetUserAsync(this.User)
                       ?? throw new ApplicationException(
                           $"Unable to load the user with ID '{userManager.GetUserId(this.User)}'");

            var changePasswordResult =
                await this.userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);

            if (!changePasswordResult.Succeeded)
            {
                AddErrors(changePasswordResult);
                return View(model);
            }

            await this.signInManager.SignInAsync(user, false);
            return RedirectToAction("Administration");
        }
        public IActionResult Administration()
        {
            return View();
        }

        [HttpGet]
        [Authorize]
        public IActionResult Edit()
        {
            var model = new PersonEditViewModel
            {
                Countries = new SelectList(this.readOnlyManager.GetAllCountries(), "Id", "Title"),
                Banks = (SelectList) new SelectList(this.readOnlyManager.GetAllBanks(), "Code", "Name")
                    .Prepend(new SelectListItem("", ""))
            };

            var signedInPerson =
                this.personManager
                    .FindByUserId(this.userManager.FindByNameAsync(User.Identity?.Name).Result.Id);

            this.mapper.Map(signedInPerson.PersonDetail, model);
            this.mapper.Map(signedInPerson.Address, model);
            this.mapper.Map(signedInPerson.BankAccount, model);

            if (signedInPerson.AddressId != signedInPerson.DeliveryAddressId)
            {
                model.DeliveryAddressIsAddress = false;
                model.CityDelivery = signedInPerson.DeliveryAddress.City;
                model.CountryIdDelivery = signedInPerson.DeliveryAddress.CountryId;
                model.OrientationNumber = signedInPerson.DeliveryAddress.OrientationNumber;
                model.RegistryNumberDelivery = signedInPerson.DeliveryAddress.RegistryNumber;
                model.StreetDelivery = signedInPerson.DeliveryAddress.Street;
                model.ZipDelivery = signedInPerson.DeliveryAddress.Zip;
            }
            else
            {
                model.DeliveryAddressIsAddress = true;
            }

            return View(model);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Edit(PersonEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = this.userManager.FindByNameAsync(User.Identity?.Name).Result;
                InsertOrEditPerson(model, user.Id, user.Person.Id);
                this.AddFlashMessage(new FlashMessage("The data has been successfully saved.", FlashMessageType.Success));
                return RedirectToAction("Administration");
            }

            model.Countries = new SelectList(this.readOnlyManager.GetAllCountries(), "Id", "Title");
            model.Banks = new SelectList(this.readOnlyManager.GetAllBanks()
                .Prepend(new Bank()), "Code", "Name");

            return View(model);
        }
        
        private IActionResult RedirectToLocal(string returnUrl)
        {
            return Url.IsLocalUrl(returnUrl)
                ? Redirect(returnUrl)
                : RedirectToAction(nameof(HomeController.Index), "Home");
        }
        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }
    }
}