using System;
using System.Collections.Generic;

namespace Telfair_Backend.Classes.Models
{
    public class CurriculumDetailModel
    {
        public CurriculumDetailModel() { }
        public string Id { get; set; }
        public long MyId { get; set; }
        public string CurriculumId { get; set; }
        public string CurriculumName { get; set; }
        public string LessonId { get; set; }
        public string LessonName{ get; set; }
        public string Objectives { get; set; }
        public int Status { get; set; }
        public int Week { get; set; }
        public int Term { get; set; }
        public string Day { get; set; }
        public string SubjectName { get; set; }
        public bool Selected { get; set; }
    }

    public class CurriculumDetailsPagedModel : PageModel
    {
        public List<CurriculumDetailModel> CurriculumDetailsModels { get; set; }

        public CurriculumDetailsPagedModel()
        {
            CurriculumDetailsModels = new List<CurriculumDetailModel>();
        }
    }
}