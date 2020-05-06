using System;
using System.Collections.Generic;
using Telfair_Backend.Classes.Entity;

namespace Telfair_Backend.Classes.Models
{
    public class HomeWorkModel
    {
        public string Title { get; set; }
        public string Id { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime DateLimit { get; set; }
        public string Description { get; set; }
        public string SubjectId { get; set; }
        public int Status { get; set; }
        public List<EmployeeSubjectModel> EmployeeSubjectModels { get; set; }
        public List<Attachments> Attachments { get; set; }
        public string LevelNodeId { get; set; }
        public string DepartmentNodeId { get; set; }
        public string ActionId { get; set; }
        public bool Selected { get; set; }

        public string AttachmentsDOM()
        {
            string dom = "";
            if(Attachments != null && Attachments.Count > 0)
            {
                dom += "<hr/>";
                dom += "<div class='form-group'><div class='form-group has-feedback'>";
                dom += "<label>Attached files</label>";
                foreach(Attachments attachment in Attachments)
                {
                    dom += "<p><img style = 'height: 20px;' src = '/icons/" + attachment.Type + ".png' /> " + attachment.FileName + "<span style = 'float: right;' ><a href = '/" + attachment.FilePath + "' download = 'download' target = '_blank' ><i class='fa fa-download'></i></a> &nbsp;&nbsp;&nbsp; <a href = '/Homework/ViewFile?fileId=" + attachment.Id + "'><i class='fa fa-eye'></i></a></span></p>";
                }
                dom += "</div></div>";
            }
            return dom;
        }
    }
}
