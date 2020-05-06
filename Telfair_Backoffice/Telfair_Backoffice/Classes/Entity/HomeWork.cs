using System;
using System.Collections.Generic;

namespace Telfair_Backend.Classes.Entity
{
    public partial class HomeWork
    {
        public string Title { get; set; }
        public string Id { get; set; }
        public string SubjectId { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime DateLimit { get; set; }
        public string Description { get; set; }
        public int? Status { get; set; }
        public string ActionId { get; set; }
        public virtual HomeWork_Action Action { get; set; }
    }
}
