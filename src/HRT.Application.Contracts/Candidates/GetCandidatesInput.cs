using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace HRT.Candidates
{
    public class GetCandidatesInput : PagedAndSortedResultRequestDto
    {
        // These are the parameter for admin searching
        // TODO Implement them as they are implemented in Repository with min max values
        [CanBeNull]
        public string? FilterText { get; set; }
        [CanBeNull]
        public string? FullName { get; set; }
        [CanBeNull]
        public DateTime? DateOfBirth { get; set; }
        [CanBeNull]
        public int? Experience { get; set; }
        [CanBeNull]
        public DepartmentType? Department { get; set; }
    }
}
