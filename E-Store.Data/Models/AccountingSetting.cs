namespace E_Store.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    using Microsoft.AspNetCore.Mvc;
    
    public class AccountingSetting
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Enter a valid from date")]
        [Display(Name = "Valid from")]
        [DataType(DataType.Date)]
        public DateTime ValidFrom { get; set; }
        
        [Required(ErrorMessage = "Enter a valid to date")]
        [Display(Name = "Valid to")]
        [DataType(DataType.Date)]
        public DateTime ValidTo { get; set; }
        
        [Required(ErrorMessage = "Enter the VAT rate")]
        [Display(Name = "VAT rate")]
        [Range(0, int.MaxValue, ErrorMessage = "The VAT rate must not be negative")]
        public int Vat { get; set; }
        
        [Required(ErrorMessage = "Select the accountant")]
        [Display(Name = "Accountant")]
        [ForeignKey("AccountantDetail")]
        public int AccountantDetailId { get; set; }
        
        [Required(ErrorMessage = "Select the seller")]
        [Display(Name = "Seller")]
        [ForeignKey("Seller")]
        public int SellerId { get; set; }
        
        public virtual Person Seller { get; set; }
        public virtual PersonDetail AccountantDetail { get; set; }
    }
}