using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.Context
{
    public interface IDataContext
    {
        IDbConnection Connection { get; }
        Task<IDbConnection> CreateConnectionAsync();
        void Dispose();
    }
}
