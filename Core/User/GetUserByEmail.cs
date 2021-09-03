using Core.User.Interfaces;
using DataAcess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.User
{
    public class GetUserByEmail : IGetUserByEmail
    {
        IUserRepository _userRepository;

        public GetUserByEmail(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Model.User> Execute(string email)
        {
            var result = await _userRepository.GetUserByEmail(email);

            return result;
        }
    }
}
