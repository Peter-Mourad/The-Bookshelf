using LibraryManagementWebApplication.Models;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagementWebApplication.ViewModels
{
    public class RegisterViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required"), DataType(DataType.Password)]
        [StringLength(1000,MinimumLength = 6, ErrorMessage = "password length must be at least 6")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Confirm Password is required")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords don't match")]
        public string ConfirmPassword { get; set; }
    }
}
