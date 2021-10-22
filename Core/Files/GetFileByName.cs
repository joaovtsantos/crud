using Core.Files.Interfaces;
using Core.Infrastructure.Exceptions;
using DataAcess.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Files
{
    public class GetFileByName : IGetFileByName
    {
        IFileUploadRepository _fileUploadRepository;
        const String folderName = "files";
        readonly String folderPath = Path.Combine(Directory.GetCurrentDirectory(), folderName);

        public GetFileByName(IFileUploadRepository fileUploadRepository)
        {
            _fileUploadRepository = fileUploadRepository;

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
        }

        public async Task<dynamic> Execute(Guid userId, string fileName)
        {
            var getFile = await _fileUploadRepository.GetFileByName(userId, fileName);

            if (getFile == null)
            {
                throw new ApiDomainException("Nenhum arquivo encontrado!");
            }

            var filePath = Path.Combine(folderPath, getFile.FileName);

            if (System.IO.File.Exists(filePath))
            {
                var b = (await System.IO.File.ReadAllBytesAsync(filePath), "application/octet-stream", getFile.FileName);

                return b;
            }

            return null;

        }
    }
}
