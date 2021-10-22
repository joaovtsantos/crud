using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Files.Interfaces
{
    public interface IGetFileByName
    {
        Task<dynamic> Execute(Guid userId, string fileName);
    }
}
