using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TorreControlCspharma.Pages.Auth
{
    public class LogoutModel : PageModel
    {
        
        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                HttpContext.Session.Clear();
                return RedirectToPage("/Index");
            }
            catch( Exception ex)
            {
                return RedirectToPage("/ErrorPage");
            }
        }
    }
}
