using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Models.ViewModels;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Diagnostics;

namespace SportsStore.Controllers
{
    public class AccountController:Controller
    {

        //Authentication & Authorization
        private UserManager<IdentityUser> userManager;
        private SignInManager<IdentityUser> signInManager;

        public AccountController(UserManager<IdentityUser> userMgr, SignInManager<IdentityUser> signInMgr) //DI for UserManager and SignInManager
        {
            userManager = userMgr;
            signInManager = signInMgr;
        }

        public ViewResult Login(string returnUrl)
        {
            return View(
                new LoginModel
                {
                    ReturnUrl = returnUrl  // redirect the user after a successful login
                }
            );
        }

        [HttpPost]
        [ValidateAntiForgeryToken]//Prevent (CSRF) attacks by ensuring that the request includes a valid anti-forgery token.
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = await userManager.FindByNameAsync(loginModel.Name); //Searches for a user with the specified username

                if (user != null)
                {
                    //Signs out any existing user sessions &  starts a fresh sign-in process, preventing issues like concurrent logins
                    await signInManager.SignOutAsync(); 
                    if ((await signInManager.PasswordSignInAsync(user, loginModel.Password, false, false)).Succeeded)
                    {
                        return Redirect(loginModel?.ReturnUrl ?? "/Admin");
                    }
                }
                ModelState.AddModelError("", "Invalid name or password");
            }
            return View(loginModel);
        }
        [Authorize]
        public async Task<RedirectResult> Logout(string returnUrl = "/")
        {
            await signInManager.SignOutAsync();
            return Redirect(returnUrl);
        }
    }
}
