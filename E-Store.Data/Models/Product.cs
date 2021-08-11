namespace E_Store.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public class Product
    {
        public Product()
        {
            ImagesCount = 0;
            Hidden = false;
            this.CategoryProducts = new List<CategoryProduct>();
        }
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Enter the code ")]
        [StringLength(255, ErrorMessage = "The code is too long")]
        [Display(Name = "Product code")]
        public string Code { get; set; }
        
        [Required(ErrorMessage = "Enter the URL ")]
        [StringLength(255, ErrorMessage = "The URL is too long")]
        [RegularExpression(@"^[a-zA-Z0-9\-]+$", ErrorMessage = "Use letters without accent characters and numbers only")]
        [Display(Name = "Url")]
        public string Url { get; set; }
        
        [Required(ErrorMessage = "Enter the title")]
        [StringLength(255, ErrorMessage = "The title is too long")]
        [Display(Name = "Title")]
        public string Title { get; set; }
        
        [Required(ErrorMessage = "Enter the short description")]
        [StringLength(255, ErrorMessage = "The short description is too long")]
        [Display(Name = "Short description")]
        public string ShortDescription { get; set; }
        
        [Required(ErrorMessage = "Enter the description")]
        [Display(Name = "Description")]
        public string Description { get; set; }
        
        [Required(ErrorMessage = "Enter the price")]
        [Display(Name = "Price")]
        [Range(0, double.MaxValue, ErrorMessage = "The price cannot be negative")]
        public decimal Price { get; set; }
        
        [Display(Name = "Price before discount")]
        [Range(1, double.MaxValue, ErrorMessage = "The price before discount has to be greater than zero")]
        public decimal? OldPrice { get; set; }
        
        [Required(ErrorMessage = "Enter the number of items in stock")]
        [Display(Name = "In stock")]
        [Range(0, int.MaxValue, ErrorMessage = "The number of items in stock cannot be negative")]
        public int Stock { get; set; }
        
        [Display(Name = "Total number of product pictures")]
        [Range(0, int.MaxValue, ErrorMessage = "The number of pictures cannot be negative")]
        public int ImagesCount { get; set; }
        
        [Display(Name = "Hidden")]
        public bool Hidden { get; set; }
        public virtual ICollection<CategoryProduct> CategoryProducts { get; set; }
               
    }
}