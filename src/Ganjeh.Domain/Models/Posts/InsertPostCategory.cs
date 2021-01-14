using System.ComponentModel.DataAnnotations;

namespace Ganjeh.Domain.Models.Posts
{
    public class InsertPostCategory
    {
        [Required]
        public string Title { get; set; }
    }
}