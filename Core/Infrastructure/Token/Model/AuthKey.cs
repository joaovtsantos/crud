using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Infrastructure.Token.Model
{
    public class AuthKey
    {
        public string PublicKey { get; set; }
        public string PrivateKey { get; set; }
        public string FacebookAppId { get; set; }
        public string GoogleAppId { get; set; }
    }
}
