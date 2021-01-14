using System.ComponentModel.DataAnnotations;

namespace Ganjeh.Domain.Models.Posts
{
    public class InsertPost
    {
        [Required]
        public string Title { get; set; }
    }
}