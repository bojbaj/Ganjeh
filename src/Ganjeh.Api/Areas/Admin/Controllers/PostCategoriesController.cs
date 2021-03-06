﻿using System.Threading.Tasks;
using Ganjeh.Api.Areas.Admin.Base;
using Ganjeh.Domain.Entities;
using Ganjeh.Domain.Interfaces;
using Ganjeh.Domain.Models.Posts;
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
        public async Task<IActionResult> Post([FromBody] InsertPostCategory model)
        {
            var result = await postCategoryServices.Add(model);
            if (result.Status)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdatePostCategory model)
        {
            var result = await postCategoryServices.Update(model);
            if (result.Status)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeletePostCategory model)
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
