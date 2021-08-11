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
    
    [ExceptionsToMessageFilter]
    public class ProductController : Controller
    {
        private IProductManager productManager;
        private ICategoryManager categoryManager;

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
            
            productManager.SaveProduct(model.Product);
            categoryManager.UpdateProductCategories(model.Product.Id, selectedCategories);
            
            this.AddFlashMessage("The product was successfully saved.", FlashMessageType.Success);
            return RedirectToAction("Administration", "Account");
        }
    }
}