using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using QrMenu.ViewModels;
using RestSharp;

namespace QrMenu.Controllers
{

    public class AccountController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerModel)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser()
                {

                    UserName = registerModel.UserName,
                    Email = "zivanka.miteva@gmail.com"
                };

                var result = await _userManager.CreateAsync(user, registerModel.Password);

                if (result.Succeeded)
                { await _signInManager.SignInAsync(user, false);
                  RedirectToAction("Login", "Admin");
                }
                
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("",error.Description);
                }

            }
            
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginModel)
        {
            //se proveriva dali validacijata definirana so data anotacija vo LoginViewModel-ot e validna
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(loginModel.UserName, loginModel.Password, loginModel.RememberMe, false);

                if (result.Succeeded)
                {
                    string rememberMe = loginModel.RememberMe.ToString();
                    if (rememberMe == "True")
                    {
                        CookieOptions options = new()
                        {
                            Expires = DateTime.Now.AddMonths(1),
                            Path = ""
                        };

                        Response.Cookies.Append("username", loginModel.UserName);
                        Response.Cookies.Append("password", loginModel.Password);
                      
                    
                    }

                    return RedirectToAction("Logged", "Admin");
                }


            }
            
            //Ako validacijata ne e validna prikazhi gi greshkite koi se definirani vo span tagovite vo Login.html
            ModelState.AddModelError("CustomError", "Faild to Login.Please check username or password");
            //Ako validacijata definirana so anotacijata pomine no sepak nema takov korisnik vo bazata redirektiraj na
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }


    }
}

