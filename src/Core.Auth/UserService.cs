using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Core.Auth.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Core.Auth
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IConfiguration _configuration;
        public UserService(UserManager<ApplicationUser> userManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            _configuration = configuration;
        }

        public async Task<TypedResult<RegisterResponse>> RegisterAsync(RegisterRequest req, IEnumerable<string> roles)
        {
            var userExists = await userManager.FindByNameAsync(req.Username);
            if (userExists != null)
                return new TypedResult<RegisterResponse>(false, "User already exists!", null);

            ApplicationUser user = new ApplicationUser()
            {
                Email = req.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = req.Username
            };
            var result = await userManager.CreateAsync(user, req.Password);
            if (!result.Succeeded)
                return new TypedResult<RegisterResponse>(false, "User creation failed! Please check user details and try again.", null);

            if (roles != null)
            {
                foreach (string role in roles)
                {
                    await userManager.AddToRoleAsync(user, role);
                }
            }

            LoginRequest loginRequest = new LoginRequest()
            {
                Username = req.Username,
                Password = req.Password
            };
            TypedResult<LoginResponse> loginResponse = await LoginAsync(loginRequest);
            if (!loginResponse.Status)
            {
                return new TypedResult<RegisterResponse>(false, loginResponse.Message, null);
            }
            return new TypedResult<RegisterResponse>(new RegisterResponse() { Token = loginResponse.Data.Token, Expiration = loginResponse.Data.Expiration });
        }

        public async Task<TypedResult<LoginResponse>> LoginAsync(LoginRequest model)
        {
            var user = await userManager.FindByNameAsync(model.Username);
            if (user != null && await userManager.CheckPasswordAsync(user, model.Password))
            {
                var userRoles = await userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id),
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddHours(3),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );

                var loginResponse = new LoginResponse()
                {
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    Expiration = token.ValidTo
                };
                return new TypedResult<LoginResponse>(loginResponse);
            }
            return new TypedResult<LoginResponse>(false, "User name or password is invalid!", null);
        }

    }
}