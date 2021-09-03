using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRest.Model
{
    public class FilterRequest : PaginationRequest
    {
        public string Term { get; set; }
    }
}
