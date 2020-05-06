using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Telfair_Backend.Classes.Models
{
    public class RoleAccessControlModel
    {
        public string RoleId { get; set; }
        public List<MenuModel> MenuModels { get; set; }
    }
}
