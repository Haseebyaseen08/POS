using Microsoft.AspNetCore.Identity;
using POS.Data.Entities;
using POS.Models.DTO;
using POS.Repositories.Abstract;
using System.Security.Claims;

namespace POS.Repositories.Implementation
{
    public class UserAuthenticationService(SignInManager<ApplicationUser> signInManager, RoleManager<ApplicationRoles> roleManager, UserManager<ApplicationUser> userManager) : IUserAuthenticationService
    {
        private readonly SignInManager<ApplicationUser> signInManager = signInManager;
        private readonly RoleManager<ApplicationRoles> roleManager = roleManager;
        private readonly UserManager<ApplicationUser> userManager = userManager;
        public async Task<Status> Login(Login request)
        {
            var response = new Status();
            var user = await userManager.FindByNameAsync(request.Username);
            if (user == null)
            {
                response.StatusCode = 404;
                response.Message = "User not found";
                return response;
            }

            if(!await userManager.CheckPasswordAsync(user, request.Password))
            {
                response.StatusCode = 401;
                response.Message = "Invalid Password";
                return response;
            }

            var signInResult = await signInManager.PasswordSignInAsync(user, request.Password, false, true);

            if (signInResult.Succeeded)
            {
                var userRole = await userManager.GetRolesAsync(user);
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, request.Username),
                    new Claim(ClaimTypes.Role, userRole.First())
                };

                response.StatusCode = 200;
                response.Message = "User logged in successfully";
                return response;
            }
            else if (signInResult.IsLockedOut)
            {
                response.StatusCode = 400;
                response.Message = "User locked out";
                return response;
            }
            else
            {
                response.StatusCode = 400;
                response.Message = "Error on login";
                return response;
            }
        }

        public async Task Logout()
        {
            await signInManager.SignOutAsync();
        }

        public async Task<Status> Register(Registration request)
        {
            var response = new Status();
            var userExist = await userManager.FindByNameAsync(request.Username);
            if (userExist != null)
            {
                response.StatusCode = 400;
                response.Message = "User already exist";
                return response;
            }

            ApplicationUser user = new ApplicationUser
            {
                Email = request.Email,
                NormalizedEmail = request.Email.ToUpper(),
                UserName = request.Username,
                NormalizedUserName = request.Username,
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var userResult = await userManager.CreateAsync(user, request.Password);

            if(!userResult.Succeeded)
            {
                response.StatusCode = 400;
                response.Message = "User creation failed";
                return response;
            }

            await userManager.AddToRoleAsync(user, "User");

            response.StatusCode = 200;
            response.Message = "User registered successfully";
            return response;
        }

    }
}
