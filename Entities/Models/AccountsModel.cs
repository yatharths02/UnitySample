using Entities.Models;
using System;
using System.ComponentModel.DataAnnotations;


namespace Entities
{
    public class UserMasterViewModel : OutputVar
    {
        [Required]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }

    public class ChangePasswordViewModel : UserMasterViewModel
    {

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

    }

    public class LoginViewModel : UserMasterViewModel
    {
        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class ForgotPasswordViewModel 
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }
    }
    public class UserInfo : UserMasterViewModel
    {
        [Required]
        public bool isActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

    }
}
