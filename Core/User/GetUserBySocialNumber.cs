using Core.User.Interfaces;
using DataAcess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.User
{
    public class GetUserBySocialNumber : IGetUserBySocialNumber
    {
        IUserRepository _userRepository;

        public GetUserBySocialNumber(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Model.User> Execute(string socialNumber)
        {
            var result = await _userRepository.GetUserBySocialNumberAsync(socialNumber);

            return result;
        }
    }
}
