using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Telfair_Backend.Classes.Models
{
    public partial class RoleModel
    {
        public string Id { get; set; }
        public long MyId { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string LastUpdatedBy { get; set; }
        public int Status { get; set; }
    }
}
