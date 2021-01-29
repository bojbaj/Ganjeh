using System.Threading.Tasks;
using Ganjeh.Api.Areas.Customer.Base;
using Ganjeh.Domain.Entities;
using Ganjeh.Domain.Interfaces;
using Ganjeh.Domain.Models.Posts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Ganjeh.Api.Areas.Customer.Controllers
{
    public class PostCategoriesController : CustomerApiController
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
    }
}
