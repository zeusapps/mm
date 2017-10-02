using System;

namespace Mm.Core.DTOs
{
    public partial class ObjPropertiesDto
    {
        public Guid PropertyId { get; set; }
        public byte[] Marked { get; set; }
        public string PropertyName { get; set; }
    }
}
