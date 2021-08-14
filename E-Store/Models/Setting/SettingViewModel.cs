namespace E_Store.Models.Setting
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.ComponentModel.DataAnnotations;

    using System.Collections.Generic;
    using E_Store.Data.Models;

    public class SettingViewModel
    {
        public AccountingSetting Entity { get; set; }
        
        public List<AccountingSetting> AllSettings { get; set; }
        
        public SelectList Accountants { get; set; }
        
        public SelectList Sellers { get; set; }
        
        [Required]
        public string SellerId { get; set; }
        
        [Display(Name = "Signature")]
        [Required(ErrorMessage = "Please upload an image of the signature")]
        public IFormFile UploadedImage { get; set; }
    }
}