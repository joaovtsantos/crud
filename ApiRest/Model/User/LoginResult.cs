using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRest.Model.User
{
    public class LoginResult
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Token { get; set; }
        public string Email { get; set; }

        public static implicit operator LoginResult(Core.User.Model.User model)
        {
            if (model == null)
                return null;

            return new LoginResult
            {
                Name = model.Name,
                Email = model.Email,
                Token = model.Token,
                UserId = model.UserId
            };
        }
    }
}
