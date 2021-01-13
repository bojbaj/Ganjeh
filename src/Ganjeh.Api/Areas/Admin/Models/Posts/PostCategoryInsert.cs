using System.ComponentModel.DataAnnotations;

namespace Ganjeh.Api.Areas.Admin.Models.Posts
{
    public class PostCategoryInsert
    {
        [Required]
        public string Title { get; set; }
    }
}