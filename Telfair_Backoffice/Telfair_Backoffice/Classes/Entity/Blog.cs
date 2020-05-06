using System;
using System.Collections.Generic;

namespace Telfair_Backend.Classes.Entity
{
    public partial class Blog
    {
        public string Id { get; set; }
        public long MyId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateOfIssue { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int Status { get; set; }
    }
}
