using Microsoft.AspNetCore.Identity;

namespace WebApplication3.Model
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName {  get; set; }
        public string CreditCard {  get; set; }
		public string Gender { get; set; }
		public string MobileNo { get; set; }
		public string DeliveryAddress { get; set; }
		public string Photo { get; set; } // Assuming this is a file name or URL
		public string AboutMe { get; set; }
	}
}
