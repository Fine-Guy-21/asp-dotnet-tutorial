using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using World_of_Soccer.Models;

namespace World_of_Soccer.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;

        public AccountController (UserManager<AppUser> userManager ,SignInManager<AppUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [AllowAnonymous]
        
        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login(string returnurl)
        {
            if (returnurl == null)                 
                returnurl = "/";

            Login login = new Login();
            login.ReturnUrl = returnurl;
            return View(login);
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(Login login)
        {
            //if(login.ReturnUrl==null)
            //{
            //    login.ReturnUrl = "Home/Index";
            //}
            if (ModelState.IsValid)
            {
                AppUser appuser = await userManager.FindByEmailAsync(login.Email);
                if (appuser != null)
                {
                    await signInManager.SignOutAsync();
                    Microsoft.AspNetCore.Identity.SignInResult result = await signInManager
                        .PasswordSignInAsync(appuser, login.Password, false, false);
                    if (result.Succeeded)
                    {
                        if (login.ReturnUrl != null) 
                        { 
                            return Redirect(login.ReturnUrl ?? "/");
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }
                } 
                else 
                {
                    ModelState.AddModelError(nameof(login.Email),"Login Failed: Invalid Email or Password Combination");
                }
            }
            return View(login);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Logout(string returnUrl)
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        

        public IActionResult Index()
        {
            return View();
        }
    }
}
