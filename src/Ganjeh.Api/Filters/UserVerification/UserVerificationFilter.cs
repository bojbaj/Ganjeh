using System.Linq;
using System.Security.Claims;
using Ganjeh.Domain.Enums;
using Ganjeh.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Ganjeh.Api.Filters.UserVerification
{
    public class UserVerificationFilter : IAuthorizationFilter
    {
        private readonly AppDbContext _dbContext;
        private readonly RoleEnum _role;
        public UserVerificationFilter(AppDbContext dbContext, RoleEnum role)
        {
            _dbContext = dbContext;
            _role = role;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.User;
            if (user == null)
            {
                context.Result = new UnauthorizedResult();
                return;
            }
            var roles = context.HttpContext.User.Claims.Where(x => x.Type == ClaimTypes.Role).Select(x => x.Value);

            if (!roles.Any(x => x.Equals(_role.ToString())))
            {
                context.Result = new UnauthorizedResult();
            }
        }
    }
}