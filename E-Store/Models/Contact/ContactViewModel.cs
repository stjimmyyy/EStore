
namespace E_Store.Models.Contact
{
    using System.ComponentModel.DataAnnotations;

    public class ContactViewModel
    {
        [Display(Name = "Your email")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Fill in a valid email address")]
        [Required(ErrorMessage = "Fill in your email address")]
        public string SenderEmail { get; set; }
        
        [Display(Name = "Message subject")]
        [Required(ErrorMessage = "Fill in the message subject")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "The subject must be 5 to 30 characters long")]
        public string Subject { get; set; }
        
        [Display(Name = "Message text")]
        [Required(ErrorMessage = "Enter message text")]
        [StringLength(3000, MinimumLength = 20, ErrorMessage = "Your message must be 20 to 3000 characters long ")]
        public string MessageBody { get; set; }
    }
}