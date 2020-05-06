using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Telfair_Backend.Classes.Models
{
    public class LinkModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Href { get; set; }
        public int Status { get; set; }
        public bool Cheked { get; set; }
    }
}
