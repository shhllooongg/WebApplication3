using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication3.Model;

namespace WebApplication3.Pages
{
    public class LandingModel : PageModel
    {
        private readonly UserManager<ApplicationUser> userManager;

        public ApplicationUser UserDetail { get; set; }

        public LandingModel(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        public void OnGet()
        {
            var userId = HttpContext.Session.GetString("UserId");

            if (string.IsNullOrEmpty(userId))
            {
                // Redirect to the login page if the session is not available
                 RedirectToPage("/Login");
            }
            // Fetch user details from UserManager or Database
            UserDetail = userManager.GetUserAsync(User).Result;
        }
    }
}