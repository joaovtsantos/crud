using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRest.Model.User
{
    public class LoginUserRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public static implicit operator Core.User.Model.User(LoginUserRequest loginUserRequest)
        {
            if (loginUserRequest == null)
                return null;

            return new Core.User.Model.User
            {
                Email = loginUserRequest.Email,
                Password = loginUserRequest.Password
            };
        }
    }
}
