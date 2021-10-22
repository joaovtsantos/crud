using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRest.Model.Files
{
    public class FileUploadRequest
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public Guid UserId { get; set; }
        public string FilePath { get; set; }

        public static implicit operator Core.Files.Model.Files(FileUploadRequest fileUploadRequest)
        {
            if (fileUploadRequest == null)
            {
                return null;
            }

            return new Core.Files.Model.Files
            {
                Id = fileUploadRequest.Id,
                FileName = fileUploadRequest.FileName,
                UserId = fileUploadRequest.UserId,
                FilePath = fileUploadRequest.FilePath,
            };
        }
    }
}
