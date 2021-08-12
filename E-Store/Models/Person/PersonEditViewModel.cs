namespace E_Store.Models.Person
{
    using System.ComponentModel.DataAnnotations;

    using Classes;

    using Microsoft.AspNetCore.Mvc.Rendering;
    
    public class PersonEditViewModel : BasePersonViewModel
    {
        [Display(Name = "Bank code")]
        [RequiredIfNotEmpty("AccountNumber", ErrorMessage = "Please, enter the bank code")]
        public string BankCode { get; set; }
        
        [Display(Name = "Account number")]
        [RequiredIfNotEmpty("BankCode", ErrorMessage = "Please, enter the account number")]
        [StringLength(20)]
        public string AccountNumber { get; set; }
        
        [Display(Name = "Registry entry")]
        public string RegistryEntry { get; set; }
        
        public SelectList Banks { get; set; }
    }
}