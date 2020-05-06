using System;
using System.Collections.Generic;

namespace Telfair_Backend.Classes.Models
{
    public class EmployeeModel
    {
        public string Id { get; set; }
        public long MyId { get; set; }
        public string PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
        public int Age { get; set; }
        public string Address { get; set; }
        public string EmployeeTypeId { get; set; }
        public int Status { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string HashCode { get; set; }
        public string UserRoleId { get; set; }
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public IEnumerable<EmployeeSubjectModel> EmployeeSubjects { get; set; }
        public string Subjects { get; set; }
        public string EmployeeId { get; set; }
        //public string LevelNodeId { get; set; }

    }
}