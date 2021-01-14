using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ganjeh.Domain.Models;
using Ganjeh.Domain.Models.DTOs.Post;
using Ganjeh.Domain.Models.Posts;

namespace Ganjeh.Domain.Interfaces
{
    public interface IPostService
    {
        Task<TypedResult<ICollection<PostDTO>>> GetList(Guid PostCategoryId, int pageSize = 0, int pageNumber = 0);
        Task<TypedResult<PostDTO>> Add(InsertPost entity);
        Task<TypedResult<PostDTO>> Update(UpdatePost entity);
        Task<TypedResult<bool>> Remove(Guid Id);
    }
}