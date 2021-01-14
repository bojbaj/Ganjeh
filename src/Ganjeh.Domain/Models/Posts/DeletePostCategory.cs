using System;
using System.ComponentModel.DataAnnotations;
using Ganjeh.Domain.Filters.Validations;

namespace Ganjeh.Domain.Models.Posts
{
    public class DeletePostCategory
    {
        [Required]
        [NonEmptyGuid]
        public Guid Id { get; set; }
    }
}