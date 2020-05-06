using System;

namespace Telfair_Backend.Classes.Models
{
    public class NodeModel
    {
        public NodeModel() { }
        public string Id { get; set; }
        public string ParentNodeId { get; set; }
        public string ParentNodeName { get; set; }
        public long MyId { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string NodeTypeId { get; set; }
        public int Status { get; set; }



    }
}