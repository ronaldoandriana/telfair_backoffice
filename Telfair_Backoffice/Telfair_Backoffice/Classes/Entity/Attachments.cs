using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Telfair_Backend.Classes.Entity
{
    public class Attachments
    {
        public string Id { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string Type { get; set; }
        public string IdHomework { get; set; }
        public int Status { get; set; }
    }
}
