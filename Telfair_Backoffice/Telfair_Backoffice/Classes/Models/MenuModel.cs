using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Telfair_Backend.Classes.Models
{
    public partial class MenuModel
    {
        public MenuModel() { }
        public string MenuId { get; set; }
        public string MenuName { get; set; }
        public string MenuFa_Fa { get; set; }
        public List<LinkModel> LinkModels { get; set; }
    }
}
