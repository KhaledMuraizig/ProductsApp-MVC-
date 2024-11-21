using Microsoft.AspNetCore.Identity;
using ProductsApp.Data;
using ProductsApp.Models;

namespace ProductsApp.Services
{
    public class AccountService: IAccountService
    {
        UserManager<User> userManager;
        SignInManager<User> signInManager;
        RoleManager<IdentityRole> roleManager;
        ProductsContext context;

        public AccountService(UserManager<User> _userManager,
                              SignInManager<User> _signInManager,
                              RoleManager<IdentityRole> _roleManager,
                              ProductsContext _context)
        {
            userManager = _userManager;
            signInManager = _signInManager;
            roleManager = _roleManager;
            context = _context;
        }
        public async Task<bool> CreateUser(SignUpDTO signUpDTO)
        {
            bool IsSuccess=true;

            User user = new User();

            user.FirstName = signUpDTO.FirstName;
            user.LastName = signUpDTO.LastName;
            user.Email = signUpDTO.Email;
            user.UserName = signUpDTO.Username;

            var CreateResult = await userManager.CreateAsync(user,signUpDTO.Password);

            if (CreateResult.Succeeded)
            {
                var RoleResult = await userManager.AddToRoleAsync(user, signUpDTO.RoleName);
                {
                    if (!RoleResult.Succeeded)
                    {
                        await userManager.DeleteAsync(user);
                        IsSuccess = false;
                    }
                }
            }
            else
            {
                IsSuccess = false;
            }
            return IsSuccess;
        }

        public async Task<SignInResult> Login(SignInDTO signInDTO)
        {
            var result = await signInManager.PasswordSignInAsync(signInDTO.Username, signInDTO.Password, signInDTO.RememberMe, false);
            return result;
        }

        public async Task<IdentityResult> AddRole(RoleDTO roleDTO)
        {
            IdentityRole role = new IdentityRole();
            role.Name = roleDTO.Name;
            var result= await roleManager.CreateAsync(role);
            return result;
        }

        public List<RoleDTO> GetRoles()
        {
            List<IdentityRole> AllRoles= roleManager.Roles.ToList();
            List<RoleDTO> roles = new List<RoleDTO>();
            foreach (IdentityRole role in AllRoles)
            {
                RoleDTO roleDTO = new RoleDTO();
                roleDTO.Name = role.Name;
                roleDTO.RoleId=role.Id;
                roles.Add(roleDTO);
            }
            return roles;
        }

        public async Task Logout()
        {
           await signInManager.SignOutAsync();
        }

      
    }
}
