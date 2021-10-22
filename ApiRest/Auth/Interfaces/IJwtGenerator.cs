using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRest.Auth.Interfaces
{
    public interface IJwtGenerator
    {
        string CreateUserAuthToken(Guid userId);
    }
}
