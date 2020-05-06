using System;
using System.Collections.Generic;

namespace Telfair_Backend.Classes.Entity
{
    public partial class PlanDetail
    {
        public string Id { get; set; }
        public long MyId { get; set; }
        public string PlanId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Status { get; set; }

        public virtual Plan Plan { get; set; }
    }
}
