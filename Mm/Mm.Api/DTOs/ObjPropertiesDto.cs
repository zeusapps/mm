using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mm.Api.DTOs
{
    public partial class ObjPropertiesDto
    {
        public Guid PropertyId { get; set; }
        public byte[] Marked { get; set; }
        public string PropertyName { get; set; }
    }
}
