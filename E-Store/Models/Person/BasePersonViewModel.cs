namespace E_Store.Models.Person
{
    using System.ComponentModel.DataAnnotations;
    
    using E_Store.Data.Models;
    using Classes;
    
    using Microsoft.AspNetCore.Mvc.Rendering;
    
    public class BasePersonViewModel
    {
        [Required(ErrorMessage = "Enter the email")]
        [DataType(DataType.EmailAddress)]
        [StringLength(50, ErrorMessage = "The email is too long")]
        [Display(Name = "Email")]
        public string Email { get; set; }
        
        [RequiredIfEmpty("CompanyName", ErrorMessage = "Enter the first name")]
        [StringLength(50, ErrorMessage = "The first name is too long")]
        [Display(Name = "First name")]
        public string FirstName { get; set; }
        
        [RequiredIfNotEmpty("FirstName", ErrorMessage = "Enter the last name")]
        [StringLength(50, ErrorMessage = "The last name is too long")]
        [Display(Name = "Last name")]
        public string LastName { get; set; }
        
        [RequiredIfEmpty("FirstName", ErrorMessage = "Enter the name or other company information")]
        [StringLength(50, ErrorMessage = "The company name is too long")]
        [Display(Name = "Company name")]
        public string CompanyName { get; set; }
        
        [RequiredIfNotEmpty("CompanyName", ErrorMessage = "Enter the company identification number")]
        [Display(Name = "Identification number")]
        [RegularExpression(@"^\d{9}$", ErrorMessage = "The identification number must be 9 numbers long")]
        public string IdentificationNumber { get; set; }
        
        [RequiredIfNotEmpty("CompanyName", ErrorMessage = "Enter the tax number")]
        [StringLength(20, ErrorMessage = "The tax number is too long")]
        [Display(Name = "DIČ")]
        public string TaxNumber { get; set; }
        
        [StringLength(20, ErrorMessage = "The phone number is too long")]
        [Display(Name = "Phone number")]
        public string Phone { get; set; }
        
        [StringLength(20, ErrorMessage = "The fax number is too long")]
        [Display(Name = "Fax number")]
        public string Fax { get; set; }
        
        [Required(ErrorMessage = "Enter the street name")]
        [StringLength(30, ErrorMessage = "The street name is too long")]
        [Display(Name = "Street")]
        public string Street { get; set; }
        
        [Required(ErrorMessage = "Enter the registry number")]
        [Range(1, int.MaxValue, ErrorMessage = "The registry number must be greater than zero")]
        [Display(Name = "Registry number")]
        public int RegistryNumber { get; set; }
        
        [Display(Name = "Orientation number")]
        [Range(1, int.MaxValue, ErrorMessage = "The orientation number must be greater than zero")]
        public int? OrientationNumber { get; set; }
        
        [Required(ErrorMessage = "Enter the city name")]
        [StringLength(30, ErrorMessage = "The city name is too long")]
        [Display(Name = "City")]
        public string City { get; set; }
        
        [Required(ErrorMessage = "Enter the zip code")]
        [StringLength(10, ErrorMessage = "The zip code is too long")]
        [Display(Name = "Zip code")]
        public string Zip { get; set; }
        
        [Required(ErrorMessage = "Enter the state name")]
        [Display(Name = "State")]
        public int AddressCountryId { get; set; }
        
        [Display(Name = "The delivery address is the same as the billing address")]
        public bool DeliveryAddressIsAddress { get; set; }
        
        [RequiredIfFalse("DeliveryAddressIsAddress", ErrorMessage = "Enter the street name for delivery address")]
        [StringLength(30, ErrorMessage = "The street name is too long")]
        [Display(Name = "Street")]
        public string StreetDelivery { get; set; }
        
        [RequiredIfFalse("DeliveryAddressIsAddress", ErrorMessage = "Enter the registry number for delivery address")]
        [Display(Name = "Registry number")]
        [Range(1, int.MaxValue, ErrorMessage = "The registry number must be greater than zero")]
        public int? RegistryNumberDelivery { get; set; }
        
        [Display (Name = "Orientation number")]
        [Range(1, int.MaxValue, ErrorMessage = "The orientation number must be greater than zero")]
        public int? OrientationNumberDelivery { get; set; }
        
        [RequiredIfFalse("DeliveryAddressIsAddress", ErrorMessage = "Enter the city name for delivery address")]
        [StringLength(30, ErrorMessage = "The city name is too long")]
        [Display(Name = "City")]
        public string CityDelivery { get; set; }
        
        [RequiredIfFalse("DeliveryAddressIsAddress", ErrorMessage = "Enter the zip code for delivery address")]
        [StringLength(10, ErrorMessage = "The zip code is too long")]
        [Display(Name = "Zip code")]
        public string ZipDelivery { get; set; }
        
        [RequiredIfFalse("DeliveryAddressIsAddress", ErrorMessage = "Enter the state name for delivery address")]
        [Display(Name = "State")]
        public int CountryIdDelivery { get; set; }
        
        public SelectList Countries { get; set; }
        
        public BasePersonViewModel() {}

        public BasePersonViewModel(Person person)
        {
            if (person.AddressId != person.DeliveryAddressId)
            {
                DeliveryAddressIsAddress = false;
                CityDelivery = person.DeliveryAddress.City;
                CountryIdDelivery = person.DeliveryAddress.CountryId;
                OrientationNumberDelivery = person.DeliveryAddress.OrientationNumber;
                RegistryNumberDelivery = person.DeliveryAddress.RegistryNumber;
                StreetDelivery = person.DeliveryAddress.Street;
                ZipDelivery = person.DeliveryAddress.Zip;
            }
            else
            {

                DeliveryAddressIsAddress = true;
            }
        }
    }
}