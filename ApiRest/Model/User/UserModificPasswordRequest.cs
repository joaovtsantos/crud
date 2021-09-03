using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRest.Model.User
{
    public class UserModificPasswordRequest
    {
        public Guid UserId { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string NewConfirmPassword { get; set; }

        public static implicit operator Core.User.Model.UserModificPassword(UserModificPasswordRequest userPassword)
        {
            if (userPassword == null)
                return null;

            return new Core.User.Model.UserModificPassword
            {
                UserId = userPassword.UserId,
                NewPassword = userPassword.NewPassword,
                NewConfirmPassword = userPassword.NewConfirmPassword,
                OldPassword = userPassword.OldPassword

            };
        }
    }
}
