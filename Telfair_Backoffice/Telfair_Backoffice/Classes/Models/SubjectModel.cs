using System;

namespace Telfair_Backend.Classes.Models
{
    public class SubjectModel
    {
        public SubjectModel() { }
        public string Id { get; set; }
        public long MyId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string LevelNodeId { get; set; }
        public string DepartmentNodeId { get; set; }

        public string LevelNodeName{ get; set; }
        public int Status { get; set; }

    }
}