using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Ganjeh.Domain.Filters.Validations;

namespace Ganjeh.Domain.Models.Posts
{
    public class InsertPost
    {
        [Required]
        public string Title { get; set; }
        [Required]
        [Range(1, Int32.MaxValue, ErrorMessage = "Price isn't valid")]
        public decimal Price { get; set; }
        public string Video { get; set; }
        [Required]
        public string Image { get; set; }
        public ICollection<string> OtherImages { get; set; }
        public string Description { get; set; }
        [Required]
        [NonEmptyGuid]
        public Guid PostCategoryId { get; set; }
        [Required]
        [NonEmptyGuid]
        public Guid RegionCityId { get; set; }
        [Required]
        public string AddressLine { get; set; }
        public string ZipCode { get; set; }
        public decimal Lat { get; set; }
        public decimal Lng { get; set; }
        public ICollection<string> PhoneNumbers { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
    }
}