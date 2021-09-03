using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.User.Interfaces
{
    public interface IGetUserById
    {
        Task<Model.User> Execute(Guid userId);
    }
}
