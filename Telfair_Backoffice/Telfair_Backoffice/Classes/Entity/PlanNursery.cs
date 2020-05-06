using System;
using System.Collections.Generic;

namespace Telfair_Backend.Classes.Entity
{
    public partial class PlanNursery
    {
        public string Id { get; set; }
        public long MyId { get; set; }
        public string LessonId { get; set; }
        public string Aims { get; set; }
        public string Activities { get; set; }
        public string Materials { get; set; }
        public string Method { get; set; }
        public string OutcomesNotes { get; set; }
        public string EmployeeId { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string NodeLevelId { get; set; }
        public string Note { get; set; }
        public int Week { get; set; }
        public string Days { get; set; }
        public int NoOfChildren { get; set; }
        public string Evaluation { get; set; }
        public int Term { get; set; }
        public DateTime DateOfIssue { get; set; }
        public string PlanTypeId { get; set; }
        public int Status { get; set; }
    }
}
