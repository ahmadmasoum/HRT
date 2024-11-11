using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace HRT.Candidates
{
    public class CandidateDto : FullAuditedEntityDto<Guid>
    {
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Experience { get; set; }
        public DepartmentType Department { get; set; }
    }
}
