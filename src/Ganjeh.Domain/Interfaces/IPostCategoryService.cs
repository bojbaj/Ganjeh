using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ganjeh.Domain.Models;
using Ganjeh.Domain.Models.DTOs.Post;
using Ganjeh.Domain.Models.Posts;

namespace Ganjeh.Domain.Interfaces
{
    public interface IPostCategoryService
    {
        Task<TypedResult<ICollection<PostCategoryDTO>>> GetAll();
        Task<TypedResult<PostCategoryDTO>> Add(InsertPostCategory entity);
        Task<TypedResult<PostCategoryDTO>> Update(UpdatePostCategory entity);
        Task<TypedResult<bool>> Remove(Guid Id);
    }
}