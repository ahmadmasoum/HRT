using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.ObjectMapping;

namespace HRT.Candidates
{
    public class CandidateAppService : HRTAppService, ICandidateAppService
    {
        private readonly ICandidateRepository _candidateRepository;

        public CandidateAppService(ICandidateRepository candidateRepository)
        {
            _candidateRepository = candidateRepository;
        }

        public async Task<PagedResultDto<CandidateDto>> GetListAsync(GetCandidatesInput input)
        {
            // You can override GetCountAsync/GetListAsync in the repository so you could pass the parameters in GetCandidatesInput for service side searching 
            var totalCount = await _candidateRepository.GetCountAsync();
            List<Candidate> result = await _candidateRepository.GetListAsync();

            return new PagedResultDto<CandidateDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<Candidate>, List<CandidateDto>>(result)
            };
        }
        public async Task<CandidateDto> GetAsync(Guid id)
        {
            Candidate result = await _candidateRepository.GetAsync(id);
            return ObjectMapper.Map<Candidate, CandidateDto>(result);

        }
        public Task<CandidateDto> CreateAsync(CreateUpdateCandidateDto input)
        {
            throw new NotImplementedException();
        }

        public Task<CandidateDto> UpdateAsync(Guid id, CreateUpdateCandidateDto input)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }




    }
}
