using Ganjeh.Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Ganjeh.Api.Filters.UserVerification
{
    public class UserVerificationAttribute : TypeFilterAttribute
    {
        public UserVerificationAttribute(RoleEnum Role) : base(typeof(UserVerificationFilter))
        {
            Arguments = new object[] { Role };
        }
    }
}