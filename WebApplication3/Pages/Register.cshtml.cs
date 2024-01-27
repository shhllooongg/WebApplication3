using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication3.Model;
using WebApplication3.ViewModels;

namespace WebApplication3.Pages
{
    public class RegisterModel : PageModel
    {

        private UserManager<ApplicationUser> userManager { get; }
        private SignInManager<ApplicationUser> signInManager { get; }

        [BindProperty]
        public Register RModel { get; set; }

        public RegisterModel(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }


        public void OnGet()
        {
        }


        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
				var dataProtectionProvider = DataProtectionProvider.Create("EncryptData");
				var protector = dataProtectionProvider.CreateProtector("MySecretKey");

                var existingUser = await userManager.FindByEmailAsync(RModel.Email);

                if (existingUser != null)
                {
                    // checking for duplicate email
                    ModelState.AddModelError($"{nameof(RModel)}.{nameof(RModel.Email)}", "Email is already registered");
                    return Page();
                }

                var user = new ApplicationUser()
				{
					UserName = RModel.Email,
					Email = RModel.Email,
					FullName = RModel.FullName,
					CreditCard = protector.Protect(RModel.CreditCard),
					Gender = RModel.Gender,
					MobileNo = RModel.MobileNo,
					DeliveryAddress = RModel.DeliveryAddress,
					Photo = RModel.Photo?.FileName,
					AboutMe = RModel.AboutMe
				};
				var result = await userManager.CreateAsync(user, RModel.Password);
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, false);
                    HttpContext.Session.SetString("UserId", RModel.Email);
                    return RedirectToPage("Landing");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return Page();
        }







    }
}
