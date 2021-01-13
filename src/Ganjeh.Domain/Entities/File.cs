using Ganjeh.Domain.Base;
using Ganjeh.Domain.Enums;

namespace Ganjeh.Domain.Entities
{
    public class File : BaseEntity
    {
        public string Title { get; set; }
        public string Source { get; set; }
        public FileTypeEnum FileType { get; set; }
        public RecordTypeEnum RecordType { get; set; }
    }
}