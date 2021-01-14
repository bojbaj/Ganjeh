using System.Threading.Tasks;
using Ganjeh.Api.Areas.Admin.Base;
using Ganjeh.Domain.Entities;
using Ganjeh.Domain.Interfaces;
using Ganjeh.Domain.Models.Posts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Ganjeh.Api.Areas.Admin.Controllers
{
    public class PostsController : AdminApiController
    {
        private readonly IPostService postServices;
        private readonly ILogger<PostsController> _logger;

        public PostsController(IPostService postServices, ILogger<PostsController> logger)
        {
            this.postServices = postServices;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await postServices.GetList();
            if (result.Status)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] InsertPost model)
        {
            var result = await postServices.Add(model);
            if (result.Status)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdatePost model)
        {
            var result = await postServices.Update(model);
            if (result.Status)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeletePost model)
        {
            var result = await postServices.Remove(model.Id);
            if (result.Status)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
