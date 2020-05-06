using System;
using System.Collections.Generic;

namespace Telfair_Backend.Classes.Entity
{
    public partial class EmployeeType
    {
        public EmployeeType()
        {
            Employee = new HashSet<Employee>();
        }

        public string Id { get; set; }
        public long MyId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }

        public virtual ICollection<Employee> Employee { get; set; }
    }
}
