using Microsoft.AspNetCore.Identity;
using ProductsApp.Models;

namespace ProductsApp.Services
{
    public interface IAccountService
    {
        Task<bool> CreateUser(SignUpDTO signUpDTO);
        Task<SignInResult> Login(SignInDTO signInDTO);
        Task<IdentityResult> AddRole(RoleDTO roleDTO);
        List<RoleDTO> GetRoles();
        Task Logout();
    }
}