using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Telfair_Backend.Classes.Models
{
    public class PersonModel
    {
        public string Id { get; set; }
        public string EmployeeId { get; set; }
        [Required]
        [Display(Name = "First name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [Display(Name = "Middle name")]
        public string MiddleName { get; set; }

        public PersonModel()
        {
            FirstName = string.Empty;
            MiddleName = string.Empty;
            LastName = string.Empty;
        }
    }
}
