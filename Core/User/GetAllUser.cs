using Core.Model;
using Core.User.Interfaces;
using DataAcess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.User
{
    public class GetAllUser : IGetAllUser
    {
        IUserRepository _userRepository;

        public GetAllUser(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<PaginationResponse<Model.User>> Execute(int pageSize = 20, int pageIndex = 1, string sort = "", string direction = "")
        {
            List<Model.User> resultList = new List<Model.User>();

            var result = await _userRepository.GetAllAsyncPagination(pageSize, pageIndex, sort, direction);

            foreach (var item in result.DataList)
            {
                resultList.Add(item);
            }

            return new PaginationResponse<Model.User>()
            {
                PageIndex = result.PageIndex,
                PageSize = result.PageSize,
                TotalRecords = result.TotalRecords,
                ResultList = resultList
            };
        }
    }
}
