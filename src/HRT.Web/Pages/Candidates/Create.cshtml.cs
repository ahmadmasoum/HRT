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

        [BindProperty]
        public UploadFileDto UploadFileDto { get; set; }

        public bool Uploaded { get; set; } = false;

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
                await UploadFileDto.File.CopyToAsync(memoryStream);

                Candidate.Resume.Content = memoryStream.ToArray();
                Candidate.Resume.Name = UploadFileDto.Name;

                await _candidateAppService.CreateAsync(Candidate);
            }

            return Page();
        }


    }

    public class UploadFileDto
    {
        public IFormFile File { get; set; }
        public string Name { get; set; }
    }
}
