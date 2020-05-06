using System;
using System.Collections.Generic;

namespace Telfair_Backend.Classes.Models
{
    public partial class EmployeeSubjectModel
    {
        public string Id { get; set; }
        public int MyId { get; set; }
        public string SubjectId { get; set; }
        public string SubjectName { get; set; }
        public string LevelNodeId { get; set; }
        public string LevelNodeName { get; set; }
        public string EmployeeId { get; set; }
        public bool Selected { get; set; }
        public int Status { get; set; }
    }
}
