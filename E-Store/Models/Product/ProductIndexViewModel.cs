namespace E_Store.Models.Product
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc.Rendering;
    
    using X.PagedList;
    using E_Store.Data.Models;
    
    public class ProductIndexViewModel
    {
        public IPagedList<Product> Products { get; set; }
        
        public decimal? StartPrice { get; set; }
        
        public decimal? EndPrice { get; set; }
        
        public bool InStock { get; set; }
        
        public string SortCriteria { get; set; }
        
        public int? CurrentCategoryId { get; set; }
        
        public string CurrentPhrase { get; set; }

        public double Rating { get; set; }

        public List<SelectListItem> SortList { get; set; } = new List<SelectListItem>()
        {
            new SelectListItem() { Text = "Rating",      Value = "rating" },
            new SelectListItem() { Text = "Lowest price",  Value = "lowest_price" },
            new SelectListItem() { Text = "Highest price",  Value = "highest_price" },
            new SelectListItem() { Text = "Newest",     Value = "newest" }
        };
    }
}