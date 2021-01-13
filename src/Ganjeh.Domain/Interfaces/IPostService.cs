using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ganjeh.Domain.Entities;
using Ganjeh.Domain.Models;
using Ganjeh.Domain.Models.DTOs.Post;

namespace Ganjeh.Domain.Interfaces
{
    public interface IPostService
    {
        Task<TypedResult<ICollection<PostDTO>>> GetList();
        Task<TypedResult<PostDTO>> Add(Post entity);
        Task<TypedResult<PostDTO>> Update(Post entity);
        Task<TypedResult<bool>> Remove(Guid Id);
    }
}