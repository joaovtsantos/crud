using DataAcess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<bool> RegisteredEmailAsync(string email);
        Task<bool> RegisteredSocialNumberAsync(string socialNumber);
        Task<User> GetUserByEmailAsync(string email);
        Task<List<User>> GetUserByNameAsync(string name);
        Task<User> GetUserBySocialNumberAsync(string socialNumber);
        Task<User> GetByEmailPasswordAsync(string email, string password);
        Task<bool> UpdateAsyncPassword(User user);

    }
}
