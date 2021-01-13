using System.Threading.Tasks;
using Ganjeh.Api.Areas.Admin.Base;
using Ganjeh.Api.Areas.Admin.Models.Posts;
using Ganjeh.Domain.Entities;
using Ganjeh.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Ganjeh.Api.Areas.Admin.Controllers
{
    public class PostCategoriesController : AdminApiController
    {
        private readonly IPostCategoryService postCategoryServices;
        private readonly ILogger<PostCategoriesController> _logger;

        public PostCategoriesController(IPostCategoryService postCategoryServices, ILogger<PostCategoriesController> logger)
        {
            this.postCategoryServices = postCategoryServices;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await postCategoryServices.GetAll();
            if (result.Status)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PostCategoryInsert model)
        {
            PostCategory postCategory = new PostCategory()
            {
                Title = model.Title
            };
            var result = await postCategoryServices.Add(postCategory);
            if (result.Status)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] PostCategoryUpdate model)
        {
            PostCategory postCategory = new PostCategory()
            {
                Id = model.Id,
                Title = model.Title
            };
            var result = await postCategoryServices.Update(postCategory);
            if (result.Status)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] PostCategoryDelete model)
        {
            var result = await postCategoryServices.Remove(model.Id);
            if (result.Status)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
