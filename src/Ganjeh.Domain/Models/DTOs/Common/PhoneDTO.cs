using Ganjeh.Domain.Enums;

namespace Ganjeh.Domain.Models.DTOs.Common
{
    public class PhoneDTO : BaseDTORecord
    {
        public string Number { get; set; }
        public RecordTypeEnum RecordType { get; set; }
    }
}