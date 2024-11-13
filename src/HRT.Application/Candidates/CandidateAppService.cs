using HRT.BlobStorage;
using HRT.Permissions;
using Microsoft.AspNetCore.Authorization;
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
    // TODO Disable RemoteService and move all api's to controller
    //[RemoteService(false)]
    [Authorize(HRTPermissions.Candidates.Default)]

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
            var totalCount = await _candidateRepository.GetCountAsync(input.FilterText);
            List<Candidate> result = await _candidateRepository.GetListAsync(input.FilterText, sorting: input.Sorting, maxResultCount: input.MaxResultCount, skipCount: input.SkipCount);

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

        [AllowAnonymous]
        public async Task<CandidateDto> CreateAsync(CreateUpdateCandidateDto input)
        {
            // TODO Add Specifications for server side validation age/name
            Guid candidateId = GuidGenerator.Create();
            string candidateResumeName = string.Join("_", candidateId.ToString(), input.Resume.Name);

            Candidate entity = new Candidate(candidateId, input.FullName, input.DateOfBirth, input.Experience, input.Department, candidateResumeName);

            entity = await _candidateRepository.InsertAsync(entity, autoSave: true);

            try
            {
                input.Resume.Name = candidateResumeName;
                await _fileAppService.SaveBlobAsync(input.Resume);

                return ObjectMapper.Map<Candidate, CandidateDto>(entity);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, message: ex.Message);
                throw new BusinessException("HRT:ExceptionWhileSavingResume");
            }
        }

        // TODO 
        [Authorize(HRTPermissions.Candidates.Edit)]
        public Task<CandidateDto> UpdateAsync(Guid id, CreateUpdateCandidateDto input)
        {
            throw new NotImplementedException();
        }

        // TODO 
        [Authorize(HRTPermissions.Candidates.Default)]
        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }




    }
}
