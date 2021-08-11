namespace E_Store.Models.User
{
    using System.ComponentModel.DataAnnotations;
    
    public class ChangePasswordViewModel
    {
        [Required(ErrorMessage = "The current password field is required.")]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }
        
        [Required(ErrorMessage = "The New password field is required")]
        [StringLength(100, ErrorMessage = "Password has to be at least 8 characters long.", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }
        
        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The entered passwords don't match")]
        public string ConfirmPassword { get; set; }
    }
}