using LibraryManagementWebApplication.Data;
using LibraryManagementWebApplication.Models;
using LibraryManagementWebApplication.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementWebApplication.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(AppDbContext appDbContext, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _appDbContext = appDbContext;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Register()
        {
            var registerViewModel = new RegisterViewModel();
            return View(registerViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if(!ModelState.IsValid)
            {
                return View(registerViewModel);
            }
            var checkEmail = await _userManager.FindByEmailAsync(registerViewModel.Email);
            if(checkEmail != null)
            {
                TempData["RegistrationError"] = "This email is arleady registered in another account!";
                return View(registerViewModel);
            }

            var user = new User()
            {
                FirstName = registerViewModel.FirstName,
                LastName = registerViewModel.LastName,
                Email = registerViewModel.Email,
                UserName = registerViewModel.Email
            };
            var createUserResult = await _userManager.CreateAsync(user, registerViewModel.Password);
            if (createUserResult.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "User");
                return RedirectToAction("Index", "Home");
            }
            return BadRequest(createUserResult.Errors);
        }

        public IActionResult Login()
        {
            var loginViewModel = new LoginViewModel();
            return View(loginViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(loginViewModel);
            }
            try
            {
                var user = await _userManager.FindByEmailAsync(loginViewModel.Email);
                if (user != null)
                {
                    var isPasswordValid = await _userManager.CheckPasswordAsync(user, loginViewModel.Password);
                    if (isPasswordValid)
                    {
                        var res = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, false, false);
                        if (res.Succeeded)
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }
                    TempData["LoginError"] = "Wrong Credentials!";
                    return View(loginViewModel);
                }
                TempData["LoginError"] = "There's no user with this email address";
                return View(loginViewModel);
            } 
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
