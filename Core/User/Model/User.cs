using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.User.Model
{
    public class User
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string SocialNumber { get; set; }
        public string AuthenticationToken { get; set; }
        public bool Status { get; set; }
        public string Token { get; set; }


        public static implicit operator User(DataAcess.Entities.User user)
        {
            if (user == null)
                return null;

            return new User
            {
                UserId = user.UserId,
                Name = user.Name,
                Email = user.Email,
                Password = user.Password,
                SocialNumber = user.SocialNumber,
                Status = user.Status
            };
        }

        public static implicit operator DataAcess.Entities.User(User model)
        {
            if (model == null)
                return null;

            return new User
            {
                UserId = model.UserId,
                Name = model.Name,
                Email = model.Email,
                Password = model.Password,
                SocialNumber = model.SocialNumber,
                Status = model.Status,
            };
        }
    }
}