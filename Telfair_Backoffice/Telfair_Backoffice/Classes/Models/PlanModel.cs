using System;
using System.ComponentModel.DataAnnotations;

namespace Telfair_Backend.Classes.Models
{
    public class PlanModel
    {
        public PlanModel() { }
        public string Id { get; set; }
        public long MyId { get; set; }
        public string LessonId { get; set; }
        public string LessonName { get; set; }
        public string Aims { get; set; }
        public string Activities { get; set; }
        public string Materials { get; set; }
        public string Method { get; set; }
        public string OutcomesNotes { get; set; }
        public string EmployeeIds { get; set; }
        public string EmployeeNames { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime DateFrom { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime DateTo { get; set; }      
        public string NodeDepartmentId { get; set; }
        public string NodeLevelId { get; set; }
        public string NodeLevelName { get; set; }
        public string NodeLevelDescription { get; set; }
        public string SubjectId{ get; set; }
        public string SubjectName { get; set; }
        public string Note { get; set; }
        public string Days { get; set; }
        public string Evaluation { get; set; }
        public int Duration { get; set; }
        public int? NoOfChildren { get; set; }
        public int Week { get; set; }
        public int Term { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfIssue { get; set; }
        public string PlanTypeId { get; set; }
        public string PlanTypeName { get; set; }
        public int Status { get; set; }

    }
    public partial class PlanSummaryModel
    {
        public string Id { get; set; }
        public string SubjectId { get; set; }
        public string EmployeeId { get; set; }
        public int? Term { get; set; }
        public string SubjectName { get; set; }
        public string EmployeeName { get; set; }
        public string Level { get; set; }
        
        public string Duration { get; set; }
        public int? Week { get; set; }
    }
}