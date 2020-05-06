using System;

namespace Telfair_Backend.Classes.Models
{
    public partial class NodeHierarchyModel
    {
        public NodeHierarchyModel() { }
        public string Id { get; set; }
        public long MyId { get; set; }
        public string NodeId { get; set; }
        public string ParentNodeId { get; set; }
        public int Status { get; set; }
    }
}