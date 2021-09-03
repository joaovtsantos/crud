using Core.User.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Core.User.Validators
{
    public class PasswordValidator : IPasswordValidator
    {
        public bool IsPasswordValidator(string password)
        {
            if (string.IsNullOrEmpty(password))
                return false;

            var rgx = Regex.IsMatch(password, "^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[$@$!%*?&]){8,30}");
            return rgx;
        }
    }
}
