using Core.User.Interfaces;
using DataAcess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.User
{
    public class GetUserById : IGetUserById
    {
        IUserRepository _userRepository;

        public GetUserById(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Model.User> Execute(Guid userId)
        {
            return await _userRepository.GetByIdAsync(userId);
        }
    }
}
