using System.Threading.Tasks;
using Core.Auth;
using Core.Auth.Models;
using Ganjeh.Api.Areas.Admin.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Ganjeh.Api.Areas.Admin.Controllers
{
    public class RegisterController : AdminApiController
    {
        private readonly IUserService userService;
        private readonly ILogger<RegisterController> _logger;

        public RegisterController(ILogger<RegisterController> logger, IUserService userService)
        {
            _logger = logger;
            this.userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RegisterRequest registerRequest)
        {
            var result = await userService.RegisterAsync(registerRequest);
            if (result.Status)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
    }
}
