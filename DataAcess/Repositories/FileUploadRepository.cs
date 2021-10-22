using Dapper;
using DataAcess.Context;
using DataAcess.Entities;
using DataAcess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.Repositories
{
    public class FileUploadRepository : Repository<Files>, IFileUploadRepository
    {
        private readonly IDataContext _dataContext;

        public FileUploadRepository(IDataContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Files> GetFileByName (Guid userId, string fileName)
        {
            string query = $"SELECT * FROM [dbo].[Files] WHERE UserId = '{userId}' AND FileName = '{fileName}'";

            var files = await _dataContext.Connection.QueryFirstOrDefaultAsync<Files>(query, new { userId = userId, fileName = fileName });

            return files;
        }

    }
}
