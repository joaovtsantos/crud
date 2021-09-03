using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.User.Model
{
    public class UserModificPassword
    {
        public Guid UserId { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string NewConfirmPassword { get; set; }

        public static implicit operator UserModificPassword(DataAcess.Entities.User model)
        {
            if (model == null)
                return null;

            return new UserModificPassword
            {
                UserId = model.UserId,
                OldPassword = model.Password,
            };
        }
    }
}
