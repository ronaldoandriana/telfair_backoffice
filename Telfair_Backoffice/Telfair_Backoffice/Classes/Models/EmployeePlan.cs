using System;

namespace Telfair_Backend.Classes.Models
{
    public class EmployeePlanModel
    {
        public EmployeePlanModel() { }
        public string Id { get; set; }
        public long MyId { get; set; }
        public string PlanId { get; set; }
        public string EmployeeId { get; set; }
        public int Status { get; set; }

    }
}