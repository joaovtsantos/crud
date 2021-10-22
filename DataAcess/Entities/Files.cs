using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.Entities
{
    public class Files
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public Guid UserId { get; set; }
        public string FilePath { get; set; }

    }
}
