namespace E_Store.Models.Person
{
    using System.ComponentModel.DataAnnotations;
    
    public class PersonRegisterViewModel : BasePersonViewModel
    {
        [Required(ErrorMessage = "Enter the password")]
        [StringLength(50, ErrorMessage = "The password is too long")]
        [MinLength(8, ErrorMessage = "The password is too short - at least 8 characters")]
        [Display(Name = "Password")]
        public virtual string Password { get; set; }
        
        [Required(ErrorMessage = "Confirm your password")]
        [StringLength(50, ErrorMessage = "The password is too long")]
        [MinLength(8, ErrorMessage = "The password is too short - at least 8 characters")]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The passwords must match")]
        public string PasswordRepeat { get; set; }
    }
}