using System;

namespace Ganjeh.Domain.Models.DTOs
{
    public class BaseListItemDTORecord : BaseDTORecord
    {
        public string Image { get; set; }
        public bool Selected { get; set; }
    }
}