using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication3.Model;
using WebApplication3.ViewModels;

namespace WebApplication3.Pages
{
    public class LoginModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;

        [BindProperty]
        public Login LModel { get; set; }

        public LoginModel(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await userManager.FindByEmailAsync(LModel.Email);

            if (user != null)
            {
                var result = await signInManager.PasswordSignInAsync(user, LModel.Password, false, lockoutOnFailure: true);

                if (result.Succeeded)
                {
                    HttpContext.Session.SetString("UserId", LModel.Email);


                    return RedirectToPage("/Landing"); 
                }

            }

            ModelState.AddModelError(string.Empty, "Invalid login attempt");
            return Page();
        }
    }
}
