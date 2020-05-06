using System;
using System.Collections.Generic;

namespace Telfair_Backend.Classes.Entity
{
    public partial class EmployeePlan
    {
        public string Id { get; set; }
        public long MyId { get; set; }
        public string EmployeeId { get; set; }
        public string PlanId { get; set; }
        public int Status { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
