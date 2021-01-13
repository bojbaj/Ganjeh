using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ganjeh.Domain.Entities;
using Ganjeh.Domain.Models;
using Ganjeh.Domain.Models.DTOs.Post;

namespace Ganjeh.Domain.Interfaces
{
    public interface IPostCategoryService
    {
        Task<TypedResult<ICollection<PostCategoryDTO>>> GetAll();
        Task<TypedResult<PostCategoryDTO>> Add(PostCategory entity);
        Task<TypedResult<PostCategoryDTO>> Update(PostCategory entity);
        Task<TypedResult<bool>> Remove(Guid Id);
    }
}