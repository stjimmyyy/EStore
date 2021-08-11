namespace E_Store.Models.User
{
    using System.ComponentModel.DataAnnotations;

    public class LoginViewModel
    {
        [Required(ErrorMessage = "You have to enter your email to log in")]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "You have to enter your password to log in")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        [Display(Name = "Remember me")]
        public bool RememberMe { get; set; }
    }
}