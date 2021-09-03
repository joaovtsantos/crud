using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.User.UserRecovey.Model
{
    public class UserRecoveryPassword
    {
        public Guid UserId { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
    }
}
