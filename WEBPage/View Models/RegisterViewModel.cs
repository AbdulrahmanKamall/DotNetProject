namespace WEBPage.View_Models
{
    using System.ComponentModel.DataAnnotations;

    namespace WEBPage.View_Models
    {
        public class RegisterViewModel
        {
            // First and Last Name properties
            [Required(ErrorMessage = "First Name is required")]
            [StringLength(50, ErrorMessage = "First Name can't be longer than 50 characters")]
            public string FirstName { get; set; }

            [Required(ErrorMessage = "Last Name is required")]
            [StringLength(50, ErrorMessage = "Last Name can't be longer than 50 characters")]
            public string LastName { get; set; }
             
            // Email property
            [Required(ErrorMessage = "Email is required")]
            [EmailAddress(ErrorMessage = "Invalid Email Address")]
            public string Email { get; set; }

            // Password and Confirm Password properties
            [Required(ErrorMessage = "Password is required")]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Required(ErrorMessage = "Confirm Password is required")]
            [DataType(DataType.Password)]
            [Compare("Password", ErrorMessage = "Passwords do not match")]
            public string ConfirmPassword { get; set; }


            // Phone Number property
            [Required(ErrorMessage = "Phone Number is required")]
            [Phone(ErrorMessage = "Invalid Phone Number")]
            public string PhoneNumber { get; set; }

            // Address property
            [Required(ErrorMessage = "Address is required")]
            [StringLength(100, ErrorMessage = "Address can't be longer than 100 characters")]
            public string Address { get; set; }

            // Additional properties for technician registration
            // [Required(ErrorMessage = "Job Title is required")]
            public string? JobTitle { get; set; }

            // National ID property
            //  [Required(ErrorMessage = "National ID is required")]
            [StringLength(14, MinimumLength = 14, ErrorMessage = "National ID must be 14 characters long")]
            [RegularExpression(@"^\d{14}$", ErrorMessage = "National ID must be numeric and 14 digits long")]
            public string? NationalID { get; set; }

            public bool IsTechnician { get; set; }
        }
    }

}
