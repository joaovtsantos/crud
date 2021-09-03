using Core.User.UserRecovey.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRest.Model.UserRecovery
{
    public class UserRecoveryPasswordRequest
    {
        public Guid UserId { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }

        public static implicit operator UserRecoveryPassword(UserRecoveryPasswordRequest user)
        {
            if (user == null)
            {
                return null;
            }


            return new UserRecoveryPassword
            {
                Password = user.Password,
                PasswordConfirm = user.PasswordConfirm,
                UserId = user.UserId
            };
        }
    }
}
