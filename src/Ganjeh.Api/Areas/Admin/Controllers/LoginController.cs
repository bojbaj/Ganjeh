﻿using System.Threading.Tasks;
using Core.Auth;
using Core.Auth.Models;
using Ganjeh.Api.Areas.Admin.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Ganjeh.Api.Areas.Admin.Controllers
{
    public class LoginController : AdminApiController
    {
        private readonly IUserService userService;
        private readonly ILogger<LoginController> _logger;

        public LoginController(ILogger<LoginController> logger, IUserService userService)
        {
            _logger = logger;
            this.userService = userService;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] LoginRequest loginRequest)
        {
            var result = await userService.LoginAsync(loginRequest);
            if (result.Status)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
