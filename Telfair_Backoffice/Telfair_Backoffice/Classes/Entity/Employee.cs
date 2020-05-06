using System;
using System.Collections.Generic;

namespace Telfair_Backend.Classes.Entity
{
    public partial class Employee
    {
        public Employee()
        {
            EmployeePlan = new HashSet<EmployeePlan>();
            EmployeeSubject = new HashSet<EmployeeSubject>();
        }

        public string Id { get; set; }
        public long MyId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string EmployeeTypeId { get; set; }
        public int Status { get; set; }

        public virtual EmployeeType EmployeeType { get; set; }
        public virtual ICollection<EmployeePlan> EmployeePlan { get; set; }
        public virtual ICollection<EmployeeSubject> EmployeeSubject { get; set; }
    }
}
