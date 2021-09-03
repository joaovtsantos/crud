using Core.User.UserRecovey.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.User.UserRecovey.Interfaces
{
    public interface INewPassowordUserRecovery
    {
        Task<bool> Execute(UserRecoveryPassword userRecoveryPassword);
    }
}
