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
        Task<bool> RegisteredEmail(string email);
        Task<bool> RegisteredSocialNumber(string socialNumber);
        Task<User> GetUserByEmail(string email);
        Task<List<User>> GetUserByName(string name);
        Task<User> GetUserBySocialNumber(string socialNumber);

    }
}
