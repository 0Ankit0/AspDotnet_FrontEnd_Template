using System.ComponentModel.DataAnnotations;

namespace Template.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
    }
    public class RegisterModel
    {
        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is required.")]
        [Compare("Password", ErrorMessage = "Password and Confirm Password do not match.")]
        public string ConfirmPassword { get; set; }

        [Phone(ErrorMessage = "Invalid phone number.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "First Name is required.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        public string Address { get; set; }

        public string MiddleName { get; set; }

        public string FullName
        { 
            get
            {
                return string.IsNullOrEmpty(MiddleName)
                    ? $"{FirstName} {LastName}"
                    : $"{FirstName} {MiddleName} {LastName}";
            }
        }
    }
}