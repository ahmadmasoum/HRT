using HRT.BlobStorage;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.ObjectMapping;

namespace HRT.Candidates
{
    public class CandidateAppService : HRTAppService, ICandidateAppService
    {
        private readonly ICandidateRepository _candidateRepository;

        // TODO This should be replaced with domain service
        private readonly IFileAppService _fileAppService;

        public CandidateAppService(
            ICandidateRepository candidateRepository,
            IFileAppService fileAppService)
        {
            _candidateRepository = candidateRepository;
            _fileAppService = fileAppService;
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
        public async Task<CandidateDto> CreateAsync(CreateUpdateCandidateDto input)
        {
            // TODO Add Specifications for server side validation age/name
            Candidate entity = ObjectMapper.Map<CreateUpdateCandidateDto, Candidate>(input);

            entity = await _candidateRepository.InsertAsync(entity, autoSave: true);

            try
            {
                SaveBlobInputDto inputDto = new SaveBlobInputDto()
                {
                    Content = input.Resume,
                    Id = entity.Id
                };

                await _fileAppService.SaveBlobAsync(inputDto);

                return ObjectMapper.Map<Candidate, CandidateDto>(entity);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, message: ex.Message);
                throw new BusinessException("HRT:ExceptionWhileSavingResume");
            }
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
