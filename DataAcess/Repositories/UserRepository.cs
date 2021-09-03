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
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly IDataContext _dataContext;

        public UserRepository(IDataContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<bool> RegisteredEmail(string email)
        {
            string query = $"SELECT * FROM [dbo].[User] WHERE Email = '{email}'";

            var user = await _dataContext.Connection.QueryFirstOrDefaultAsync<User>(query, new { email = email });

            bool isUserExists = user != null ? true : false;

            return isUserExists;
        }

        public async Task<bool> RegisteredSocialNumber(string socialNumber)
        {
            string query = $"SELECT * FROM [dbo].[User] WHERE SocialNumber = '{socialNumber}'";

            var user = await _dataContext.Connection.QueryFirstOrDefaultAsync<User>(query, new { socialNumber = socialNumber });

            bool isUserExists = user != null ? true : false;

            return isUserExists;
        }

        public async Task<User> GetUserByEmail(string email)
        {
            string query = $"SELECT * FROM [dbo].[User] WHERE Email LIKE '%{email}%'";

            var user = await _dataContext.Connection.QueryFirstOrDefaultAsync<User>(query, new { email = email });

            return user;
        }

        public async Task<List<User>> GetUserByName(string name)
        {
            string query = $"SELECT * FROM [dbo].[User] WHERE Name LIKE '%{name}%'";

            var user = await _dataContext.Connection.QueryAsync<User>(query, new { name = name });

            return user.ToList();
        }

        public async Task<User> GetUserBySocialNumber(string socialNumber)
        {
            string query = $"SELECT * FROM [dbo].[User] WHERE socialNumber LIKE '%{socialNumber}%'";

            var user = await _dataContext.Connection.QueryFirstOrDefaultAsync<User>(query, new { socialNumber = socialNumber });

            return user;
        }
    }
}
