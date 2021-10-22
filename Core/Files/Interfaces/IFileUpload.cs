using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Files.Interfaces
{
    public interface IFileUpload
    {
        Task<Model.Files> Execute(Guid userId, string FileName, string FilePath);
    }
}
