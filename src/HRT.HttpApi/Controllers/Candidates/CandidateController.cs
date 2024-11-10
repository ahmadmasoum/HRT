using Asp.Versioning;
using HRT.Candidates;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;

namespace HRT.Controllers.Candidates
{
    [RemoteService]
    [Area("app")]
    [ControllerName("Candidate")]
    [Route("api/app/candidates")]
    public class CandidateController : AbpController
    {
        private readonly ICandidateAppService _candidateAppService;

        public CandidateController(ICandidateAppService candidateAppService)
        {
            _candidateAppService = candidateAppService;
        }
    }
}
