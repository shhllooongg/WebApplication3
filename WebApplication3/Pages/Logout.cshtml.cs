using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using WebApplication3.Model;

namespace WebApplication3.Pages
{
    public class LogoutModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;

        public LogoutModel(SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
        }


        public async Task<IActionResult> OnPost()
        {
            // Sign out the user
            await _signInManager.SignOutAsync();

            // Clear the session
            HttpContext.Session.Clear();

            // Redirect to the login page
            return RedirectToPage("/Login");
        }
    }
}
