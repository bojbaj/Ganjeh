using System.Collections.Generic;
using Ganjeh.Domain.Base;

namespace Ganjeh.Domain.Entities
{
    public class PostCategory : BaseEntity
    {
        public string Title { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}