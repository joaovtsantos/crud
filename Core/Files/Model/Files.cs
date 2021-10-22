using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Files.Model
{
    public class Files
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public Guid UserId { get; set; }
        public string FilePath { get; set; }

        public static implicit operator Files(DataAcess.Entities.Files files)
        {
            if (files == null)
            {
                return null;
            }

            return new Files
            {
                Id = files.Id,
                FileName = files.FileName,
                UserId = files.UserId,
                FilePath = files.FilePath,
            };
        }

        public static implicit operator DataAcess.Entities.Files(Files model)
        {
            if (model == null)
                return null;

            return new DataAcess.Entities.Files
            {
                Id = model.Id,
                FileName = model.FileName,
                UserId = model.UserId,
                FilePath = model.FilePath,
            };
        }
    }
}
