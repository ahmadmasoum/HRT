using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace HRT.Candidates
{
    public interface ICandidateAppService: IApplicationService
    {
        Task<PagedResultDto<CandidateDto>> GetListAsync(GetCandidatesInput input);


        Task<CandidateDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<CandidateDto> CreateAsync(CreateUpdateCandidateDto input);

        Task<CandidateDto> UpdateAsync(Guid id, CreateUpdateCandidateDto input);
    }
}
