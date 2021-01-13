using Ganjeh.Domain.Base;
using Ganjeh.Domain.Enums;

namespace Ganjeh.Domain.Entities
{
    public class Phone : BaseEntity
    {
        public string Number { get; set; }
        public RecordTypeEnum RecordType { get; set; }
    }
}