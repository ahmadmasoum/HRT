using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace HRT.BlobStorage
{
    public class BlobDto
    {
        public byte[] Content { get; set; }
        public string Name { get; set; }
    }
}
