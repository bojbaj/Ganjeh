using System.Collections.Generic;
using Ganjeh.Domain.Models.DTOs.Common;

namespace Ganjeh.Domain.Models.DTOs.Post
{
    public class PostDTO : BaseListItemDTORecord
    {
        public PostCategoryDTO Category { get; set; }
        public string Video { get; set; }
        public ICollection<string> Images { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public AddressDTO Address { get; set; }
        public ICollection<string> PhoneNumbers { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
    }
}