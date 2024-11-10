using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace HRT.Candidates
{
    public class Candidate : FullAuditedAggregateRoot<Guid>
    {
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Experience { get; set; }
        public DepartmentType Department { get; set; }
        public byte[] Resume { get; set; }
    }
}
