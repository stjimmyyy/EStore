namespace E_Store.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;

    public class Category
    {
        public Category()
        {
            this.CategoryProducts = new List<CategoryProduct>();
            this.ChildCategories = new List<Category>();
        }
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Enter the URL")]
        [StringLength(255, ErrorMessage = "The URL is too long")]
        [Display(Name = "Url")]
        public string Url { get; set; }
        
        [Required(ErrorMessage = "Enter the title")]
        [StringLength(255, ErrorMessage = "The title is too long")]
        [Display(Name = "Title")]
        public string Title { get; set; }
        
        [Required]
        public int OrderNo { get; set; }
        
        [Required]
        [Display(Name = "Hide")]
        public bool Hidden { get; set; }
        
        public int? ParentCategoryId { get; set; }
        public virtual ICollection<CategoryProduct> CategoryProducts { get; set; }
        
        [ForeignKey("ParentCategoryId")]
        [InverseProperty("ChildCategories")]
        public virtual Category ParentCategory { get; set; }
        public virtual ICollection<Category> ChildCategories { get; set; }
        
        
    }
}