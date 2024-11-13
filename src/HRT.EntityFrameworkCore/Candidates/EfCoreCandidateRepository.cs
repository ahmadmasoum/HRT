using HRT.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
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

        public async Task<List<Candidate>> GetListAsync(
            string? filterText = null,
            string? fullName = null,
            DateTime? maxDateOfBirth = null,
            DateTime? minDateOfBirth = null,
            int? maxExperience = null,
            int? minExperience = null,
            DepartmentType? Department = null,
            string? sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, fullName, maxDateOfBirth, minDateOfBirth, maxExperience, minExperience, Department);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? CandidateConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public async Task<long> GetCountAsync(
            string? filterText = null,
            string? fullName = null,
            DateTime? maxDateOfBirth = null,
            DateTime? minDateOfBirth = null,
            int? maxExperience = null,
            int? minExperience = null,
            DepartmentType? Department = null,
            CancellationToken cancellationToken = default)
        {
            var query = await GetQueryableAsync();
            query = ApplyFilter((await GetQueryableAsync()), filterText, fullName, maxDateOfBirth, minDateOfBirth, maxExperience, minExperience, Department);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }


        protected virtual IQueryable<Candidate> ApplyFilter(
            IQueryable<Candidate> query,
            string? filterText = null,
            string? fullName = null,
            DateTime? maxDateOfBirth = null,
            DateTime? minDateOfBirth = null,
            int? maxExperience = null,
            int? minExperience = null,
            DepartmentType? department = null
            )
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.FullName.Contains(filterText) || e.Experience.ToString() == filterText || e.Department.ToString().Contains(filterText))
                    .WhereIf(!string.IsNullOrWhiteSpace(fullName), e => e.FullName.Contains(fullName))
                    .WhereIf(minDateOfBirth.HasValue, e => e.DateOfBirth >= minDateOfBirth.Value)
                    .WhereIf(maxDateOfBirth.HasValue, e => e.DateOfBirth <= maxDateOfBirth.Value)
                    .WhereIf(minExperience.HasValue, e => e.Experience <= minExperience.Value)
                    .WhereIf(maxExperience.HasValue, e => e.Experience <= maxExperience.Value)
                    .WhereIf(department.HasValue, e => e.Department == department);
        }

    }
}
