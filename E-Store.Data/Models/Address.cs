namespace E_Store.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Microsoft.AspNetCore.Mvc;

    public class Address
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Enter the street")]
        [StringLength(30, ErrorMessage = "The street name is too long")]
        [Display(Name = "Street")]
        public string Street { get; set; }
        
        [Required(ErrorMessage = "Enter the registry number")]
        [Display(Name = "Registry number")]
        [Range(1, int.MaxValue, ErrorMessage = "The registry number cannot be negative")]
        public int RegistryNumber { get; set; }
        
        [Display(Name = "Orientation Number")]
        [Range(1, int.MaxValue, ErrorMessage = "The orientation number cannot be negative")]
        public int? OrientationNumber { get; set; }
        
        [Required(ErrorMessage = "Enter the city")]
        [StringLength(30, ErrorMessage = "The city name is too long")]
        [Display(Name = "City")]
        public string City { get; set; }
        
        [Required(ErrorMessage = "Enter the city")]
        [StringLength(30, ErrorMessage = "The city name is too long")]
        [Display(Name = "Zip code")]
        public string Zip { get; set; }
        
        [Required(ErrorMessage = "Select the country")]
        [Display(Name = "Country")]
        public int CountryId { get; set; }
        
        public virtual Country Country { get; set; }
    }
}