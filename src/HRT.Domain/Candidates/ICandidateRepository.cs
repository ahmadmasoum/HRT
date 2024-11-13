using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace HRT.Candidates
{
    public interface ICandidateRepository : IRepository<Candidate, Guid>
    {
        // Add Custom Logic Here
        Task<long> GetCountAsync(string? filterText = null, string? fullName = null, DateTime? maxDateOfBirth = null, DateTime? minDateOfBirth = null, int? maxExperience = null, int? minExperience = null, DepartmentType? Department = null, CancellationToken cancellationToken = default);
        Task<List<Candidate>> GetListAsync(string? filterText = null, string? fullName = null, DateTime? maxDateOfBirth = null, DateTime? minDateOfBirth = null, int? maxExperience = null, int? minExperience = null, DepartmentType? Department = null, string? sorting = null, int maxResultCount = int.MaxValue, int skipCount = 0, CancellationToken cancellationToken = default);
    }
}
