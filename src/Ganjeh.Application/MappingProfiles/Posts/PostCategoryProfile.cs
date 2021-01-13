using Ganjeh.Application.MappingProfiles.Base;
using Ganjeh.Domain.Entities;
using Ganjeh.Domain.Models.DTOs.Post;

namespace Ganjeh.Application.MappingProfiles.Posts
{
    public class PostCategoryProfile : BaseProfile
    {
        public PostCategoryProfile()
        {
            CreateMap<PostCategory, PostCategoryDTO>()
                .ReverseMap();
        }
    }
}