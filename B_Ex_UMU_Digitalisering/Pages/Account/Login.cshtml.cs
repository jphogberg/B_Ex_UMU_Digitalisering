using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace B_Ex_UMU_Digitalisering.Pages.Account
{
    public class LoginModel : PageModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "E-post")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Lösenord")]
        public string Password { get; set; }

        [Display(Name = "Kom ihåg mig?")]
        public bool RememberMe { get; set; }

        public IActionResult OnPost()
        {
            // Skall givetvis ändras
            var isValidUser = Email == "ab@b.se" && Password == "t0psecret!";

            if (!isValidUser)
            {
                ModelState.AddModelError("", "Felaktigt användarnamn eller lösenord.");
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            var scheme = CookieAuthenticationDefaults.AuthenticationScheme;

            var user = new ClaimsPrincipal(
                new ClaimsIdentity(
                    new[] { new Claim(ClaimTypes.Name, Email) },
                    scheme
                )
            );

            return SignIn(user, scheme);
        }

        public async Task<IActionResult> OnPostLogoutAsync()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToPage("/Index");
        }
    }
}