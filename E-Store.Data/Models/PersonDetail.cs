namespace E_Store.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Microsoft.AspNetCore.Mvc;
    
    public class PersonDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Enter your first name")]
        [StringLength(50, ErrorMessage = "The first name is too long")]
        [Display(Name = "First name")]
        public string Firstname { get; set; }
        
        [Required(ErrorMessage = "Enter your last name")]
        [StringLength(50, ErrorMessage = "The last name is too long")]
        [Display(Name = "Last name")]
        public string Lastname { get; set; }
        
        [StringLength(50, ErrorMessage = "The company name is too long")]
        [Display(Name = "Company")]
        public string CompanyName { get; set; }
        
        [StringLength(20, ErrorMessage = "The phone number is too long")]
        [Display(Name = "Phone number")]
        public string Phone { get; set; }
        
        [StringLength(20, ErrorMessage = "The fax number is too long")]
        [Display(Name = "Fax")]
        public string Fax { get; set; }
        
        [Required(ErrorMessage = "Enter your email")]
        [StringLength(100, ErrorMessage = "The email address is too long")]
        [Display(Name = "Email")]
        public string Email { get; set; }
        
        [StringLength(20, ErrorMessage = "The tax number is too long")]
        [Display(Name = "Tax number")]
        public string TaxNumber { get; set; }
        
        [Display(Name = "Identification number")]
        [StringLength(9, MinimumLength = 9)]
        public string IdentificationNumber { get; set; }
        
        [Display(Name = "Registry entry")]
        [StringLength(2048)]
        public string RegistryEntry { get; set; } // only for admin

        [NotMapped]
        public string FullName => $"{Firstname} {Lastname}";
    }
}