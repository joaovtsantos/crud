using Dapper;
using DataAcess.Context;
using DataAcess.Entities;
using DataAcess.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
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

        public async Task<bool> RegisteredEmailAsync(string email)
        {
            string query = $"SELECT * FROM [dbo].[User] WHERE Email = '{email}'";

            var user = await _dataContext.Connection.QueryFirstOrDefaultAsync<User>(query, new { email = email });

            bool isUserExists = user != null ? true : false;

            return isUserExists;
        }

        public async Task<bool> RegisteredSocialNumberAsync(string socialNumber)
        {
            string query = $"SELECT * FROM [dbo].[User] WHERE SocialNumber = '{socialNumber}'";

            var user = await _dataContext.Connection.QueryFirstOrDefaultAsync<User>(query, new { socialNumber = socialNumber });

            bool isUserExists = user != null ? true : false;

            return isUserExists;
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            string query = $"SELECT * FROM [dbo].[User] WHERE Email LIKE '%{email}%'";

            var user = await _dataContext.Connection.QueryFirstOrDefaultAsync<User>(query, new { email = email });

            return user;
        }

        public async Task<List<User>> GetUserByNameAsync(string name)
        {
            string query = $"SELECT * FROM [dbo].[User] WHERE Name LIKE '%{name}%'";

            var user = await _dataContext.Connection.QueryAsync<User>(query, new { name = name });

            return user.ToList();
        }

        public async Task<User> GetUserBySocialNumberAsync(string socialNumber)
        {
            string query = $"SELECT * FROM [dbo].[User] WHERE socialNumber LIKE '%{socialNumber}%'";

            var user = await _dataContext.Connection.QueryFirstOrDefaultAsync<User>(query, new { socialNumber = socialNumber });

            return user;
        }

        public async Task<User> GetByEmailPasswordAsync(string email, string password)
        {
            string query = $"SELECT * FROM [dbo].[User] WHERE Email = @email and Password = @password";

            var result = await _dataContext.Connection.QueryFirstOrDefaultAsync<User>(query, new { email = email, password = password });

            _dataContext.Dispose();

            return result;
        }

        public async Task<bool> UpdateAsyncPassword(User user)
        {
            using (IDbConnection conn = await _dataContext.CreateConnectionAsync())
            {
                string updateQuery = @"UPDATE [dbo].[User]
                    set Password = @Password where UserId = @UserId";

                var exe = conn.Execute(updateQuery, user);

                var res = exe > 0 ? true : false;
                return res;
            }
        }

        public async Task<bool> UpdateAsyncUser(User user)
        {
            using (IDbConnection conn = await _dataContext.CreateConnectionAsync())
            {
                string updateQuery = @"UPDATE [dbo].[User]
                    set Name = @Name, Email = @Email, SocialNumber = @SocialNumber, Status = @Status where UserId = @UserId";

                var exe = conn.Execute(updateQuery, user);

                var res = exe > 0 ? true : false;
                return res;
            }
        }
    }
}
