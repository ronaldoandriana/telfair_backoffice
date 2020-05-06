using System;
using System.Collections.Generic;

namespace Telfair_Backend.Classes.Entity
{
    public partial class CurriculumDetail
    {
        public string Id { get; set; }
        public long MyId { get; set; }
        public string CurriculumId { get; set; }
        public string LessonId { get; set; }
        public string Objectives { get; set; }
        public int? Week { get; set; }
        public string Day { get; set; }
        public int? Term { get; set; }
        public int? Status { get; set; }

        public virtual Curriculum Curriculum { get; set; }
        public virtual Lesson Lesson { get; set; }
    }

public partial class CurriculumDetailCount
    {
        public string Id { get; set; }
        public int Count { get; set; }
    }
}
