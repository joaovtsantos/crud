using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Infrastructure.Token
{
    public interface IJwtGenerator
    {
        string CreateUserAuthToken(Guid userId);
    }
}
