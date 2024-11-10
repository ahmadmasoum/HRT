using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace HRT.Candidates
{
    public interface ICandidateRepository : IRepository<Candidate, Guid>
    {
        // Add Custom Logic Here
    }
}
