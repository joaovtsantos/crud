using Core.User.Interfaces;
using DataAcess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.User
{
    public class GetUserByName : IGetUserByName
    {
        IUserRepository _userRepository;

        public GetUserByName(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<Model.User>> Execute(string name)
        {
            var result = await _userRepository.GetUserByName(name);

            List<Model.User> output = new List<Model.User>();

            foreach (var item in result)
            {
                output.Add(item);
            }

            return output;
        }
    }
}
