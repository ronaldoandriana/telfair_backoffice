using System;

namespace Telfair_Backend.Classes.Models
{
    public class EmployeeTypeModel
    {
        public EmployeeTypeModel() { }
        public string Id { get; set; }
        public long MyId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }

    }
}