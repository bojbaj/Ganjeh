using System;

namespace Ganjeh.Domain.Models.DTOs
{
    public class BaseSimpleRecord
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public bool Selected { get; set; }
    }
}