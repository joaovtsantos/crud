using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRest.Model.User
{
    public class CreateUserRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string SocialNumber { get; set; }
        public bool Status { get; set; }

        public static implicit operator Core.User.Model.User(CreateUserRequest createUserRequest)
        {
            if (createUserRequest == null)
                return null;

            return new Core.User.Model.User
            {
                Name = createUserRequest.Name,
                Email = createUserRequest.Email,
                Password = createUserRequest.Password,
                SocialNumber = createUserRequest.SocialNumber,
                Status = createUserRequest.Status
            };
        }
    }
}
