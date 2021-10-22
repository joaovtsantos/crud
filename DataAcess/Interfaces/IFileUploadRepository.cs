using DataAcess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.Interfaces
{
    public interface IFileUploadRepository : IRepository<Files>
    {
        Task<Files> GetFileByName(Guid userId, string fileName);
    }
}
