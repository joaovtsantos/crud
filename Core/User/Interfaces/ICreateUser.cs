using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.User.Interfaces
{
    public interface ICreateUser
    {
        Task<Model.User> Execute(Model.User user);
    }
}
