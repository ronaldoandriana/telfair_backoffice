using System;
using System.Collections.Generic;

namespace Telfair_Backend.Classes.Entity
{
    public partial class Plan
    {
        public Plan()
        {
            PlanDetail = new HashSet<PlanDetail>();
        }

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
        public string Days { get; set; }
        public string Evaluation { get; set; }
        public int? NoOfChildren { get; set; }
        public int Duration { get; set; }
        public int Week { get; set; }
        public int Term { get; set; }
        public DateTime DateOfIssue { get; set; }
        public string PlanTypeId { get; set; }
        public int Status { get; set; }

        public virtual Lesson Lesson { get; set; }
        public virtual Node NodeLevel { get; set; }
        public virtual PlanType PlanType { get; set; }
        public virtual ICollection<PlanDetail> PlanDetail { get; set; }
    }

  public partial class PlanSummary
    {
        public PlanSummary()
        {
        }
        public string Id { get; set; }
        public string SubjectId { get; set; }
        public string EmployeeId { get; set; }
        public int Term { get; set; }
        public string SubjectName { get; set; }
        public string EmployeeName { get; set; }
        public string Level { get; set; }
        public string Duration { get; set; }
        public int Week { get; set; }
    }

    public partial class BatchQualityControl
    {
        public BatchQualityControl()
        {
        }
        public long Id { get; set; }
        public string BatchNumber { get; set; }
        public int NumberOfDocument { get; set; }
        public DateTime ScannedOn { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }

    }
}
