using System.Collections.Generic;
using Ganjeh.Domain.Models.DTOs.Common;

namespace Ganjeh.Domain.Models.DTOs.Post
{
    public class PostDTO : BaseListItemDTORecord
    {
        public PostCategoryDTO Category { get; set; }
        public FileDTO Video { get; set; }
        public ICollection<FileDTO> Images { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public AddressDTO Address { get; set; }
        public ICollection<PhoneDTO> PhoneNumbers { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
    }
}