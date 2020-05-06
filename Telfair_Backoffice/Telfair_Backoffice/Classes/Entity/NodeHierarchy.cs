using System;
using System.Collections.Generic;

namespace Telfair_Backend.Classes.Entity
{
    public partial class NodeHierarchy
    {
        public string Id { get; set; }
        public long MyId { get; set; }
        public string NodeId { get; set; }
        public string ParentNodeId { get; set; }
        public int Status { get; set; }

        public virtual Node Node { get; set; }
        public virtual Node ParentNode { get; set; }
    }
}
