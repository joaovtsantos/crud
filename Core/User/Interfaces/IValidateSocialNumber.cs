using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.User.Interfaces
{
    public interface IValidateSocialNumber
    {
        bool IsSocialNumber(string socialNumber);
    }
}
