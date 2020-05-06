using System;
using System.Collections.Generic;

namespace Telfair_Backend.Classes.Entity
{
    public partial class Curriculum
    {
        public Curriculum()
        {
            CurriculumDetail = new HashSet<CurriculumDetail>();
        }

        public string Id { get; set; }
        public long MyId { get; set; }
        public string LevelNodeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }

        public virtual Node LevelNode { get; set; }
        public virtual ICollection<CurriculumDetail> CurriculumDetail { get; set; }
    }

    public partial class CurriculumCount
    {
        public string Id { get; set; }
        public int Count { get; set; }

    }
}
