using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShareForceOne.Models
{
    public class UserViewModel
    {
        [Key]
        public int Id { get; set; }
        

        [Required(ErrorMessage="Must provide first name.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage ="Must be between 2 and 50 characters.")]
        [DisplayName("First name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Must provide a last name.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Must be between 2 and 50 characters.")]
        [DisplayName("Last name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Must provide a gender.")]
        [DisplayName("Gender")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Must provide a valid phone number.")]
        [DisplayName("Phone number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Must provide a city.")]
        [DisplayName("City")]
        public string City { get; set; }

        [Required(ErrorMessage = "Must provide a valid Email.")]
        [DisplayName("Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Compare(nameof(Email), ErrorMessage = "Emails do NOT match")]
        [DisplayName("Confirm email")]
        public string ConfirmEmail { get; set; }

        [Required(ErrorMessage = "Must provide a valid password.")]
        [DisplayName("Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare(nameof(Password), ErrorMessage = "Passwords do NOT match")]
        [DisplayName("Confirm password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
