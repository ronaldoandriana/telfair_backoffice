using System;

namespace Telfair_Backend.Classes.Models
{
    public class PlanDetailModel
    {
        public PlanDetailModel() { }
        public string Id { get; set; }
        public long MyId { get; set; }
        public string PlanId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Progress { get; set; }
        public int Status { get; set; }

    }
}