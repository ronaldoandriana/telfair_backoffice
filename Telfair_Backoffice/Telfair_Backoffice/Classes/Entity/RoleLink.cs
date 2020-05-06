using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Telfair_Backend.Classes.Entity
{
    public class RoleLink
    {
        public string Id { get; set; }
        public string LinkId { get; set; }
        public string RoleId { get; set; }
        public int Status { get; set; }
    }
}
