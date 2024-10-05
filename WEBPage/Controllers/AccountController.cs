
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WEBPage.Models;
using WEBPage.Models.Identity;
using WEBPage.View_Models;
using WEBPage.View_Models.WEBPage.View_Models;

namespace WEBPage.Controllers
{
    public class AccountController : Controller
    {
        public UserManager<ApplicationUser> UserManager { get; }
        public SignInManager<ApplicationUser> SignInManager { get; }

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register
            (RegisterViewModel registerView)
        {
            //if (registerView.IsTechnician)
            //{
            //    if (string.IsNullOrEmpty(registerView.JobTitle))
            //    {
            //        ModelState.AddModelError("JobTitle", "Job Title is required for technicians.");
            //    }
            //    if (string.IsNullOrEmpty(registerView.NationalID))    //|| model.NationalID.Length != 14)
            //    {
            //        ModelState.AddModelError("NationalID", "National ID is required and must be 14 characters long for technicians.");
            //    }
            //}
            //if (ModelState.IsValid && registerView.IsTechnician)
            //{
            //    ApplicationUser user = new ApplicationUser();
            //    user.Address = registerView.Address;
            //    user.FirstName = registerView.FirstName;
            //    user.LastName = registerView.LastName;
            //    user.PasswordHash = registerView.Password;
            //    user.Email = registerView.Email;
            //    user.PhoneNumber = registerView.PhoneNumber;

            //    IdentityResult identityResult = await UserManager.CreateAsync(user);
            //    if (identityResult.Succeeded)
            //    {
            //        await SignInManager.SignInAsync(user, false);
            //        RedirectToAction("Index", "Home");
            //    }
            //    foreach (var item in identityResult.Errors)
            //    {
            //        ModelState.AddModelError("", item.Description);
            //    }
            //}
            if (ModelState.IsValid && !registerView.IsTechnician)
            {
                ApplicationUser user = new ApplicationUser();
                user.Address = registerView.Address;
                user.FirstName = registerView.FirstName;
                user.LastName = registerView.LastName;
                user.PasswordHash = registerView.Password;
                user.Email = registerView.Email;
                user.PhoneNumber = registerView.PhoneNumber;
                user.UserName = registerView.Email;

                IdentityResult identityResult = await UserManager.CreateAsync(user,registerView.Password);
                if (identityResult.Succeeded)
                {
                    await SignInManager.SignInAsync(user, false);
                    return RedirectToAction("Index","Home");
                }
                foreach (var item in identityResult.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }

            return View("Register",registerView);
        }
        public async Task<IActionResult> SignOut()
        {
            await SignInManager.SignOutAsync();
            return View("Login");
        }
        public IActionResult Login()
        {  
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if(ModelState.IsValid)
            {
               ApplicationUser UserLogin =  await UserManager.FindByEmailAsync(loginViewModel.Email);
               if(UserLogin!=null)
               {
                    bool IsFound = await UserManager.CheckPasswordAsync(UserLogin, loginViewModel.Password);
                    if(IsFound)
                    {
                        await SignInManager.SignInAsync(UserLogin, loginViewModel.RememberMe);
                        return RedirectToAction("Index","Home");
                    }
               }
                ModelState.AddModelError("", "UserName or password wrong");
            }
            return View("Login",loginViewModel);
        }
    }
}
