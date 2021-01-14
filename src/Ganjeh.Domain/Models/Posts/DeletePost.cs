using System;
using System.ComponentModel.DataAnnotations;
using Ganjeh.Domain.Filters.Validations;

namespace Ganjeh.Domain.Models.Posts
{
    public class DeletePost
    {
        [Required]
        [NonEmptyGuid]
        public Guid Id { get; set; }
    }
}