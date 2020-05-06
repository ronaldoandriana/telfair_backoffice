using System;
using System.Collections.Generic;

namespace Telfair_Backend.Classes.Entity
{
    public partial class PlanType
    {
        public PlanType()
        {
            Plan = new HashSet<Plan>();
        }

        public string Id { get; set; }
        public int MyId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }

        public virtual ICollection<Plan> Plan { get; set; }
    }
}
