using System;

namespace Mm.Api.Models
{
    public partial class ObjProperties
    {
        public Guid PropertyId { get; set; }
        public byte[] Marked { get; set; }
        public string PropertyName { get; set; }
    }
}
