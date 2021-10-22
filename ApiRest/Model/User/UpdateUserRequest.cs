using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRest.Model.User
{
    public class UpdateUserRequest
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string SocialNumber { get; set; }
        public bool Status { get; set; }

        public static implicit operator Core.User.Model.User(UpdateUserRequest updateUserRequest)
        {
            if (updateUserRequest == null)
                return null;

            return new Core.User.Model.User
            {
                UserId = updateUserRequest.UserId,
                Name = updateUserRequest.Name,
                Email = updateUserRequest.Email,
                SocialNumber = updateUserRequest.SocialNumber,
                Status = updateUserRequest.Status
            };
        }
    }
}
