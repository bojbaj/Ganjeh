using Ganjeh.Domain.Enums;

namespace Ganjeh.Domain.Models.DTOs.Common
{
    public class FileDTO : BaseDTORecord
    {
        public string Source { get; set; }
        public FileTypeEnum FileType { get; set; }
        public RecordTypeEnum RecordType { get; set; }
    }
}