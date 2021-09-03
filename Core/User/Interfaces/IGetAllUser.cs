using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.User.Interfaces
{
    public interface IGetAllUser
    {
        Task<PaginationResponse<Model.User>> Execute(int pageSize = 20, int pageIndex = 1, string sort = "", string direction = "");
    }
}
