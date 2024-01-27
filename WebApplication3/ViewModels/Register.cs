using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace WebApplication3.ViewModels
{
    public class Register
    {

		[Required]
		[DataType(DataType.EmailAddress)]
		[EmailAddress(ErrorMessage = "Invalid email address")]
		public string Email { get; set; }

        [Required(ErrorMessage = "A valid password is required")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{12,}$", ErrorMessage = "The password must be at least 12 characters long and include lowercase and uppercase letters, numbers, and special characters.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm password cannot be blank")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Password and confirmation password does not match")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Full Name cannot be blank")]
        [DataType(DataType.Text)]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Credit card cannot be blank")]
        [DataType(DataType.CreditCard)]
        public string CreditCard { get; set; }

		[Required(ErrorMessage = "Gender cannot be blank")]
		public string Gender { get; set; }

		[Required(ErrorMessage = "Phone number cannot be blank")]
		[DataType(DataType.PhoneNumber)]
		public string MobileNo { get; set; }

		[Required(ErrorMessage = "Delivery address cannot be blank")]
		[DataType(DataType.Text)]
		public string DeliveryAddress { get; set; }

		[DataType(DataType.Upload)]
        [RegularExpression(".*", ErrorMessage = "Only JPG files are allowed.")]

        public IFormFile Photo { get; set; }

		[Required(ErrorMessage = "About me cannot be blank")]
		[DataType(DataType.MultilineText)]
		public string AboutMe { get; set; }


	}
}
