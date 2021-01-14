using Ganjeh.Application.MappingProfiles.Base;
using Ganjeh.Domain.Entities;
using Ganjeh.Domain.Models.DTOs.Post;
using Ganjeh.Domain.Models.Posts;

namespace Ganjeh.Application.MappingProfiles.Posts
{
    public class PostCategoryProfile : BaseProfile
    {
        public PostCategoryProfile()
        {
            CreateMap<PostCategory, PostCategoryDTO>()
                .ReverseMap();

            CreateMap<InsertPostCategory, PostCategory>();
        }
    }
}