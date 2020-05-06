using System;
using System.Collections.Generic;

namespace Telfair_Backend.Classes.Entity
{
    public partial class Subject
    {
        public Subject()
        {
            EmployeeSubject = new HashSet<EmployeeSubject>();
            Lesson = new HashSet<Lesson>();
        }

        public string Id { get; set; }
        public long MyId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string LevelNodeId { get; set; }
        public int Status { get; set; }

        public virtual Node LevelNode { get; set; }
        public virtual ICollection<EmployeeSubject> EmployeeSubject { get; set; }
        public virtual ICollection<Lesson> Lesson { get; set; }
    }
}
