namespace E_Store.Controllers
{
    using System;
    using System.Linq;
    
    using Business.Interfaces;
    using Classes;
    using E_Store.Data.Models;
    using Extensions;
    using Models.Product;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    
    using X.PagedList;
    
    [ExceptionsToMessageFilter]
    public class ProductController : Controller
    {
        private readonly IProductManager productManager;
        private readonly ICategoryManager categoryManager;

        private const int pageSize = 6;

        public ProductController(ICategoryManager categoryManager, IProductManager productManager)
        {
            this.productManager = productManager;
            this.categoryManager = categoryManager;
        }

        [HttpGet]
        //[Authorize(Roles = "Admin")]
        public IActionResult Manage(string url)
        {
            var model = new ManageProductViewModel
            {
                FormCaption = string.IsNullOrEmpty(url)
                    ? "New product"
                    : "Edit product"
            };

            model.Product = !string.IsNullOrEmpty(url)
                ? productManager.FindProductByUrl(url)
                  ?? throw new NullReferenceException("Product not found.")
                : new Product();

            model.AvailableCategories = categoryManager.GetLeaves().ToList();
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Manage(ManageProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.FormCaption = model.Product.Id == 0
                    ? "New product"
                    : "Edit product";

                model.AvailableCategories = categoryManager.GetLeaves();
                
                this.AddFlashMessage("Invalid product parameters!", FlashMessageType.Danger);
                return this.View(model);
            }

            var allCategories = categoryManager.GetLeaves();

            int[] selectedCategories = allCategories
                .Where(c => model.PostedCategories[allCategories.IndexOf(c)])
                .Select(c => c.Id)
                .ToArray();

            int oldProductId = model.Product.Id;
            int oldImagesCount = model.Product.ImagesCount;
            
            productManager.SaveProduct(model.Product);
            categoryManager.UpdateProductCategories(model.Product.Id, selectedCategories);
            
            this.productManager.SaveProductImages(model.Product, model.UploadedImages, oldProductId, oldImagesCount);
            
            this.AddFlashMessage("The product was successfully saved.", FlashMessageType.Success);
            return RedirectToAction("Administration", "Account");
        }
        public void DeleteImage(int productId, int imageIndex)
        {
            this.productManager.RemoveProductImage(productId, imageIndex);
        }
        public IActionResult Index(int? id, string searchPhrase, int? page, ProductIndexViewModel model)
        {
            if (id.HasValue)
            {
                searchPhrase = string.Empty;
                model.Products = this.productManager.FindByCategoryId(id.Value).ToPagedList(1, pageSize);
                model.CurrentPhrase = string.Empty;
                model.CurrentCategoryId = id;
            }
            else if (searchPhrase != null)
            {
                model.Products = this.productManager.SearchProducts(searchPhrase).ToPagedList(1, pageSize);
                model.CurrentPhrase = searchPhrase;
                model.CurrentCategoryId = null;
            }
            else
            {
                searchPhrase = model.CurrentPhrase;
                model.Products = this.productManager.SearchProducts(model.CurrentPhrase,
                        model.CurrentCategoryId,
                        model.SortCriteria ?? "rating",
                        model.StartPrice ?? 0,
                        model.EndPrice ?? 0,
                        model.InStock)
                    .ToPagedList(page ?? 1, pageSize);
            }

            ViewData["SearchPhrase"] = searchPhrase;

            return View(model);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var product = this.productManager.FindProductById(id);
            this.productManager.CleanProduct(product, true);
            
            this.AddFlashMessage(new FlashMessage("The product was successfully deleted", FlashMessageType.Success));

            return RedirectToAction("Index");
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult ProcessStockForm(int productId, int quantity)
        {
            this.productManager.AddToStock(productId, quantity);
            
            this.AddFlashMessage(new FlashMessage("The number of products in stock was changed", FlashMessageType.Success));

            return Redirect(Request.Headers["Referer"].ToString());
        }

        public IActionResult Detail(string url)
        {
            var model = new ProductDetailViewModel
            {
                Product = this.productManager.FindProductByUrl(url)
            };

            return View(model);
        }
    }
}