using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using World_of_Soccer.Models;

namespace World_of_Soccer.Controllers
{
    public class AdminController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly IPasswordHasher<AppUser> passwordHasher; 

        public AdminController (UserManager<AppUser> userManager,IPasswordHasher<AppUser> passwordHasher)
        {
            this.userManager = userManager;
            this.passwordHasher = passwordHasher;   
        }
        public IActionResult Index()
        {
            return View(userManager.Users);
        }

        [Authorize]
        [HttpGet]
        public IActionResult Create() => View();


       [Authorize]
       [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            if (ModelState.IsValid)
            {
                AppUser appuser = new AppUser
                {
                    UserName = user.Name, 
                    Email = user.Email
                };
                IdentityResult result = await userManager.
                    CreateAsync(appuser, user.Password);

                if (result.Succeeded) { 
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    { 
                        ModelState.AddModelError("", error.Description); 
                    }
                    
                }
            }
            
                return View(user);
            
        }

        [HttpGet]
        public async Task<IActionResult> UpdateAdmin(string id)
        {
            AppUser? appuser = await userManager.FindByIdAsync(id);
            User user = new User();
            if (appuser != null)
            {
                
                    user.Name = appuser.UserName;
                    user.Email = appuser.Email;
                    user.Password = appuser.PasswordHash;

            }
            ViewData["id"] = id;
            return View(user);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateAdmin(User user,String id)
        {
            
                AppUser? appuser = await userManager.FindByIdAsync(id);
                if (appuser != null)
                {
                    appuser.UserName = user.Name;
                    appuser.Email = user.Email;
                }

                var result = await userManager.UpdateAsync(appuser);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach(IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description); 
                    }
                }
            
            return View();
        }

        public async Task<IActionResult> DeleteAdmin(string id)
        {
            AppUser? appuser = await userManager.FindByIdAsync(id);

            if(appuser != null)
            {
                var result = await userManager.DeleteAsync(appuser);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }

    }
}
