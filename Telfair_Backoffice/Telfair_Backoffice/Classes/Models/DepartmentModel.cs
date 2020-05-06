using System.Collections.Generic;

namespace Telfair_Backend.Classes.Models
{
    public class DepartmentModel
    {
        public string DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public List<GradeModel> Grades { get; set; }
    }

    public class GradeModel
    {
        public string GradeId { get; set; }
        public string GradeName { get; set; }
    }
}