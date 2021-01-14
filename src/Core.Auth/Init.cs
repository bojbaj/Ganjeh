using System.Text;
using Core.Auth.Context;
using Core.Auth.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Core.Auth
{
    public static class Init
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<IdentityDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("IdentityDbContext"));
            });

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<IdentityDbContext>()
                .AddDefaultTokenProviders();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })

            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidAudience = Configuration["JWT:ValidAudience"],
                    ValidIssuer = Configuration["JWT:ValidIssuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Secret"]))
                };
            });

            services.AddScoped<IUserService, UserService>();
        }

        public static void CreateAndMigrateAuthDB(this IdentityDbContext dbContext, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            dbContext.Database.Migrate();            
            SeedUsers(userManager, roleManager, dbContext);
        }

        public static void SeedUsers(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IdentityDbContext dbContext)
        {
            string adminRoleName = "Admin";
            if (roleManager.FindByNameAsync(adminRoleName).Result == null)
            {
                IdentityRole identityRole = new IdentityRole
                {
                    Name = adminRoleName
                };
                IdentityResult result = roleManager.CreateAsync(identityRole).Result;
            }

            string adminEmail = "bojbaj@gmail.com";
            if (userManager.FindByEmailAsync(adminEmail).Result == null)
            {
                string adminUsername = "admin";
                string adminPassword = "Pwd123456@";
                ApplicationUser identityUser = new ApplicationUser
                {
                    UserName = adminUsername,
                    Email = adminEmail
                };

                IdentityResult result = userManager.CreateAsync(identityUser, adminPassword).Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(identityUser, adminRoleName).Wait();
                }
            }
        }
    }
}