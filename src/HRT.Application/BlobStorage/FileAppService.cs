using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.BlobStoring;

namespace HRT.BlobStorage
{
    public class FileAppService : ApplicationService, IFileAppService
    {
        private readonly IBlobContainer<FileContainer> _fileContainer;

        public FileAppService(IBlobContainer<FileContainer> fileContainer)
        {
            _fileContainer = fileContainer;
        }

        public async Task SaveBlobAsync(SaveBlobInputDto input)
        {
            await _fileContainer.SaveAsync(input.Id.ToString(), input.Content, true);
        }

        public async Task<BlobDto> GetBlobAsync(GetBlobRequestDto input)
        {
            var blob = await _fileContainer.GetAllBytesAsync(input.Id.ToString());

            return new BlobDto
            {
                Id = input.Id,
                Content = blob
            };
        }
    }
}
