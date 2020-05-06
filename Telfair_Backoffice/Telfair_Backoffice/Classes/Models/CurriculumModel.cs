using System;
using System.Collections.Generic;

namespace Telfair_Backend.Classes.Models
{
    public class CurriculumModel
    {
        public CurriculumModel() { }
        public string Id { get; set; }
        public long MyId { get; set; }
        public string DepartmentNodeId { get; set; }
        public string DepartmentNodeName { get; set; }
        public string LevelNodeId { get; set; }
        public string SubjectId { get; set; }
        public string LevelNodeName { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } 
        public IEnumerable<CurriculumDetailModel> Curriculumdetails { get; set; }
        public int Status { get; set; }
        public string Weeks { get; set; }
        public string Terms { get; set; }
        public string Lessons { get; set; }
        public string Days { get; set; }
        public string Objectives { get; set; }

    }

    public class CurriculumPagedModel : PageModel
    {
        public List<CurriculumModel> CurriculumModels { get; set; }

        public CurriculumPagedModel()
        {
            CurriculumModels = new List<CurriculumModel>();
        }
    }
}