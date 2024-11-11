using HRT.BlobStorage;
using HRT.Candidates;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace HRT.Web.Pages.Candidates
{
    public class CreateModel : HRTPageModel
    {
        private readonly ICandidateAppService _candidateAppService;

        [BindProperty]
        public CreateUpdateCandidateDto Candidate { get; set; }

        public bool Uploaded { get; set; } = false;

        [BindProperty]
        public IFormFile File { get; set; }

        public CreateModel(ICandidateAppService candidateAppService)
        {
            _candidateAppService = candidateAppService;
        }

        public void OnGet()
        {

        }


        public async Task<IActionResult> OnPostAsync()
        {
            using (var memoryStream = new MemoryStream())
            {
                await File.CopyToAsync(memoryStream);

                Candidate.Resume = memoryStream.ToArray();

                await _candidateAppService.CreateAsync(Candidate);
            }

            return Page();
        }

    }
}
