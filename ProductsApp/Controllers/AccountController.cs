using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProductsApp.Models;
using ProductsApp.Services;

namespace ProductsApp.Controllers
{
    public class AccountController : Controller
    {
        IAccountService accountService;

        public AccountController(IAccountService _accountService)
        {
            accountService = _accountService;
        }
        public IActionResult Index()
        {
            vmSignUp vmSignUp = new vmSignUp();
            vmSignUp.roles=accountService.GetRoles();
            return View("NewUser",vmSignUp);
        }

        public async Task<IActionResult> CreateAccount(vmSignUp vmSignUp)
        {
            vmSignUp.roles = accountService.GetRoles();
            var result = await accountService.CreateUser(vmSignUp.signUp);

            return View("NewUser", vmSignUp);
        }

        public IActionResult SignIn()
        {
            return View("SignIn");
        }

        public async Task<IActionResult> Login(SignInDTO signInDTO)
        {
            var result= await accountService.Login(signInDTO);
            if (result.Succeeded)
            {
                return RedirectToAction("Welcome", "Account");
            }
            else
            {
                ViewData["Message"] = "Invalid username or password";
                return View("SignIn");
            }
            
        }

        public IActionResult Welcome()
        {
            return View("Welcome");
        }

        public IActionResult NewRole()
        {
            return View("NewRole");
        }

        public async Task<IActionResult> AddRole(RoleDTO roleDTO)
        {
            var result = await accountService.AddRole(roleDTO);
            if (result.Succeeded)
            {

            }
            else
            {

            }
            return View("NewRole");
        }
        public IActionResult AccessDenied()
        {
            return View("AccessDenied");
        }
        public async Task<IActionResult> Logout()
        {
            await accountService.Logout();
            return View("SignIn");
        }

        public IActionResult RolesList()
        {
            List<RoleDTO> roles = accountService.GetRoles();
            return View("RolesList", roles);
        }



        
    }
}
