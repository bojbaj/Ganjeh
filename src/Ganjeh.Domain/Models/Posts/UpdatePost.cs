using System;
using System.ComponentModel.DataAnnotations;
using Ganjeh.Domain.Filters.Validations;

namespace Ganjeh.Domain.Models.Posts
{
    public class UpdatePost
    {
        [Required]
        [NonEmptyGuid]
        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; }
    }
}