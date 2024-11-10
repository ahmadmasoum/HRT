using HRT.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace HRT.Candidates
{
    public class EfCoreCandidateRepository : EfCoreRepository<HRTDbContext, Candidate, Guid>, ICandidateRepository
    {
        public EfCoreCandidateRepository(IDbContextProvider<HRTDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        // Add Custom Logic Here 
    }
}
