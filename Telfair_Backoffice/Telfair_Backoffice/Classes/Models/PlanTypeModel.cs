using System;

namespace Telfair_Backend.Classes.Models
{
    public partial class PlanTypeModel
    {
        public string Id { get; set; }
        public int MyId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
    }
}