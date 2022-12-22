using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toplearn_Blog.Shared.Dto.Media
{
    public class MediaDto
    {
        public byte[] Bytes { get; set; }
        public string Extension { get; set; } // .jpg
        public string MimeType { get; set; } // image/jpg
        public string? Name { get; set; }
    }
}
