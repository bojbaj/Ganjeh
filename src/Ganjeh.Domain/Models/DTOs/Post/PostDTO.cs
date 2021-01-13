namespace Ganjeh.Domain.Models.DTOs.Post
{
    public class PostDTO : BaseSimpleRecord
    {
        public PostCategoryDTO Category { get; set; }

    }
}