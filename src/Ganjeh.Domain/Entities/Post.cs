using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Ganjeh.Domain.Base;

namespace Ganjeh.Domain.Entities
{
    public class Post : BaseEntity
    {
        public string Title { get; set; }
        public Guid VideoId { get; set; }
        public File Video { get; set; }
        public ICollection<File> Images { get; set; }
        [Column(TypeName = "money")]
        public decimal Price { get; set; }
        public string Description { get; set; }
        public Guid PostCategoryId { get; set; }
        public PostCategory PostCategory { get; set; }
        public Guid AddressId { get; set; }
        public Address Address { get; set; }
        public ICollection<Phone> PhoneNumbers { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
    }
}