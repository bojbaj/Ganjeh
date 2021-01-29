using System;

namespace Ganjeh.Domain.Base
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime Created { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime LastModified { get; set; }
        public Guid ModifiedBy { get; set; }
    }
}