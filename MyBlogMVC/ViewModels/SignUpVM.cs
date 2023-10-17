using System;
using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace MyBlogAPI.ViewModels
{
    public class SignUpVM
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Username is required")]
        [RegularExpression(@"^[a-zA-Z0-9]{5,10}$", ErrorMessage = "Username should contain 5 to 10 alphanumeric characters.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "FirstName is required")]
        [RegularExpression(@"^[a-zA-Z][a-zA-Z\s]*$", ErrorMessage = "Invalid Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "LastName is required")]
        [RegularExpression(@"^[a-zA-Z][a-zA-Z\s]*$", ErrorMessage = "Invalid Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [RegularExpression(@"^([0-9a-zA-Z]([\+\-_\.][0-9a-zA-Z]+)*)+@(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]*\.)+[a-zA-Z0-9]{2,3})$", ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Phone Number is required")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone Number should contain only 10 digits.")]
        public long PhoneNumber { get; set; }

        
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*\W)[a-zA-Z\d\W]{8,}$", ErrorMessage = "Password should contain Atleast one(special character, lowercase letter, uppercase letter and number)")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Password doesn't match, Type again !")]
        [DataType(DataType.Password)]


        public string ConfirmPassword { get; set;}


    }
}
