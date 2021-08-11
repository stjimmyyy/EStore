namespace E_Store.Models.Product
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    using Microsoft.AspNetCore.Http;
    
    using Data.Models;
    
    public class ManageProductViewModel
    {
        public Product Product { get; set; }

        private List<Category> availableCategories;

        public List<Category> AvailableCategories
        {
            get => availableCategories;

            set
            {
                PostedCategories = new bool[value.Count];
                availableCategories = value;
            }
        }
        
        [Required(ErrorMessage = "You must select at least one category per product.")]
        [Display(Name = "Category")]
        public bool[] PostedCategories { get; set; }
        
        [Display(Name = "Upload Image")]
        public List<IFormFile> UploadedImages { get; set; }
        
        public string FormCaption { get; set; }

        public ManageProductViewModel()
        {
            Product = new Product();
            AvailableCategories = new List<Category>();
            PostedCategories = new bool[0];
            UploadedImages = new List<IFormFile>();
        }
    }
}