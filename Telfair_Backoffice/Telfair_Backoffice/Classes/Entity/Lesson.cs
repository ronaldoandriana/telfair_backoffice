using System;
using System.Collections.Generic;

namespace Telfair_Backend.Classes.Entity
{
    public partial class Lesson
    {
        public Lesson()
        {
            CurriculumDetail = new HashSet<CurriculumDetail>();
            Plan = new HashSet<Plan>();
        }

        public string Id { get; set; }
        public long MyId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string SubjectId { get; set; }
        public int Status { get; set; }

        public virtual Subject Subject { get; set; }
        public virtual ICollection<CurriculumDetail> CurriculumDetail { get; set; }
        public virtual ICollection<Plan> Plan { get; set; }
    }
}
