using System;
using System.Collections.Generic;

namespace Telfair_Backend.Classes.Entity
{
    public partial class Node
    {
        public Node()
        {
            Curriculum = new HashSet<Curriculum>();
            NodeHierarchy = new HashSet<NodeHierarchy>();
            NodeHierarchyParent = new HashSet<NodeHierarchy>();
            Plan = new HashSet<Plan>();
            Subject = new HashSet<Subject>();
        }

        public string Id { get; set; }
        public long MyId { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string NodeTypeId { get; set; }
        public int Status { get; set; }

        public virtual NodeType NodeType { get; set; }
        public virtual ICollection<Curriculum> Curriculum { get; set; }
        public virtual ICollection<NodeHierarchy> NodeHierarchy { get; set; }
        public virtual ICollection<NodeHierarchy> NodeHierarchyParent { get; set; }
        public virtual ICollection<Plan> Plan { get; set; }
        public virtual ICollection<Subject> Subject { get; set; }
    }
}
