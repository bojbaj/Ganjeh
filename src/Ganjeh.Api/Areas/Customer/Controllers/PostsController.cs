using System;
using System.Threading.Tasks;
using Ganjeh.Api.Areas.Customer.Base;
using Ganjeh.Domain.Enums;
using Ganjeh.Domain.Entities;
using Ganjeh.Domain.Interfaces;
using Ganjeh.Domain.Models.Posts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using Ganjeh.Application.Util;

namespace Ganjeh.Api.Areas.Customer.Controllers
{
    [Authorize(Roles = nameof(RoleEnum.Customer))]
    public class PostsController : CustomerApiController
    {
        private readonly IPostClientSideService postServices;
        private readonly ILogger<PostsController> _logger;

        public PostsController(IPostClientSideService postServices, ILogger<PostsController> logger)
        {
            this.postServices = postServices;
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await postServices.GetList(PostCategoryId: Guid.Empty);
            if (result.Status)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] InsertPost model)
        {
            Guid userId = HttpContext.CurrentUserId();
            var result = await postServices.Add(userId, model);
            if (result.Status)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdatePost model)
        {
            Guid userId = HttpContext.CurrentUserId();
            var result = await postServices.Update(userId, model);
            if (result.Status)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeletePost model)
        {
            Guid userId = HttpContext.CurrentUserId();
            var result = await postServices.Remove(userId, model.Id);
            if (result.Status)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
