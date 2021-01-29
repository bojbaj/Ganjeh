using System;
using System.Linq;
using System.Security.Claims;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Ganjeh.Application.Util
{
    public static class HttpContextExtentions
    {
        public static Guid CurrentUserId(this HttpContext httpContext)
        {
            if (httpContext.User != null)
            {
                string IdValue = httpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
                return Guid.Parse(IdValue);
            }
            return Guid.Empty;
        }
    }
}