using Core.Files.Interfaces;
using DataAcess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Files
{
    public class FileUpload : IFileUpload
    {
        IFileUploadRepository _fileUploadRepository;

        public FileUpload(IFileUploadRepository fileUploadRepository)
        {
            _fileUploadRepository = fileUploadRepository;
        }

        public async Task<Model.Files> Execute(Guid userId, string fileName, string filePath)
        {
            Model.Files files = new Model.Files
            {
                FileName = fileName,
                FilePath = filePath,
                UserId = userId,
            };

            files.Id = await _fileUploadRepository.InsertAsync(files);

            return files;
        }

    }
}
