using Asp.Versioning;
using HRT.BlobStorage;
using HRT.Candidates;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;

namespace HRT.Controllers.Candidates
{
    [RemoteService]
    [Area("app")]
    [ControllerName("Candidate")]
    [Route("api/app/candidates")]
    public class CandidateController : HRTController
    {
        private readonly ICandidateAppService _candidateAppService;
        private readonly IFileAppService _fileAppService;

        public CandidateController(ICandidateAppService candidateAppService, IFileAppService fileAppService)
        {
            _candidateAppService = candidateAppService;
            _fileAppService = fileAppService;
        }


        [HttpGet]
        [Route("download-candidate-resume/{name}")]
        public async Task<IActionResult> DownloadCandidateResumeAsync(string name)
        {
            var fileDto = await _fileAppService.GetBlobAsync(new GetBlobRequestDto { Name = name });

            // Remove the Guid from the name
            string fileName = Regex.Replace(fileDto.Name, @"^[a-fA-F0-9-]{36}_", "");
            return File(fileDto.Content, "application/octet-stream", fileName);
        }
    }
}
