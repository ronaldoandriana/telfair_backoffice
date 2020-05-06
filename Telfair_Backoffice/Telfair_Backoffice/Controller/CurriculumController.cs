
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Telfair_Backend.Classes.Services;
using Telfair_Backend.Classes.Models;

namespace Telfair_Backend.Controllers
{
    public class CurriculumController : BaseController
    {
        public IActionResult Curriculum(string error)
        {
            try
            {
                if (SessionIsNull()) return Redirect("/Home/Login?mustLogin=true&next=/Curriculum/Curriculum");
                PlanService service = new PlanService();
                //CurriculumModel model = service.GetCurriculumById(Id);
                //CurriculumController model = service.GetCurriculumById(id);

                //var subject = service.ViewSubjectByLevel();
                var nodeDepartment = service.ViewNodeByNodeType(StaticData.NODE_DEPARTMENT, int.MaxValue, 1);
                ViewBag.NodeLevel = new SelectList(new List<NodeModel>(), "Id", "Name");
                ViewBag.NodeDepartment = new SelectList(nodeDepartment, "Id", "Name");
                ViewBag.Subject = new SelectList(new List<SubjectModel>(), "Id", "Name");
                ViewBag.Lesson = new SelectList(new List<LessonModel>(), "Id", "Name");
                ViewBag.isAdding = true;
                SetViewBag();
                ViewBag.disabled = "disabled='disabled'".Replace('\'', '"');
                if (!string.IsNullOrEmpty(error) && error.Equals("true")) SetSavingError();
            }
            catch (System.Exception)
            {
                SetDefaultError();
            }
            return View();

        }

        public IActionResult SaveCurriculum(CurriculumModel curriculum)
        {
            try
            {
                PlanService ser = new PlanService();
                int result = ser.SaveCurriculum(curriculum);
                SetViewBag();
                if (result.Equals(1)) return Redirect("/Curriculum/ViewCurriculum?success=true");
                else return Redirect("/Curriculum/Curriculum?error=true");
            }
            catch (System.Exception)
            {
                return Redirect("/Curriculum/Curriculum?error=true");
            }

        }

        public ActionResult ViewCurriculum(string success, string delete_success, string delete_error)
        {
            var model = new CurriculumPagedModel();
            try
            {
                if (SessionIsNull()) return Redirect("/Home/Login?mustLogin=true&next=/Curriculum/ViewCurriculum");
                model = new CurriculumPagedModel();
                SetViewBag();
                if (!string.IsNullOrEmpty(success) && success.Equals("true")) ViewBag.success = "Saving with success!";
                if (!string.IsNullOrEmpty(delete_success) && delete_success.Equals("true")) ViewBag.success = "Deleting with success!";
                if (!string.IsNullOrEmpty(delete_error) && delete_error.Equals("true")) ViewBag.error = "An error has occured while deleting!";
            }
            catch (System.Exception)
            {
                SetDefaultError();
            }

            return View(model);

        }       

        [HttpGet]
        public ActionResult Edit(string id)
        {
            try
            {
                if (SessionIsNull()) return Redirect("/Home/Login?mustLogin=true&next=/Curriculum/Edit?id="+id);
                PlanService ser = new PlanService();
                CurriculumModel model = ser.ViewCurriculumById(id);
                var nodeDepartment = ser.ViewNodeByNodeType("25da3697-59f4-11e9-8ceb-fb681531b90a", int.MaxValue, 1);
                var nodeLevel = ser.ViewNodeByParent(model.DepartmentNodeId);
                var subjects = ser.ViewSubjectByLevel(model.LevelNodeId);
                var curriculumDetails = ser.ViewAllCurriculumDetailsByCurriculum(model.SubjectId, model.Id);
                ViewBag.NodeDepartment = new SelectList(nodeDepartment, "Id", "Name");
                ViewBag.NodeLevel = new SelectList(nodeLevel, "Id", "Name");
                ViewBag.Subject = new SelectList(subjects, "Id", "Name");
                ViewBag.CurriculumDetails = curriculumDetails;
                SetViewBag();
                ViewBag.disabled = "enabled='enabled'".Replace('\'', '"');
                ViewBag.curriculumid = model.Id;
                ViewBag.subjectid = model.SubjectId;
                return View("Curriculum", model);
            }
            catch (System.Exception)
            {
                SetDefaultError();
                return View("Curriculum");
            }
        }

        public JsonResult IsCurriculumExist(string departmentId, string gradeId, string subjectId)
        {
            try
            {
                PlanService ser = new PlanService();
                string currId = ser.IsCurriculumExist(departmentId, gradeId, subjectId);
                return Json(new { status = 1, exist = !string.IsNullOrEmpty(currId), curriculumId = currId });
            }
            catch (System.Exception)
            {
                return Json(new { status = 0, exist = false, curriculumId = "" });
            }
        }

        public JsonResult ViewSubjectByLevel(string levelId)
        {
            try
            {
                PlanService ser = new PlanService();
                var subjects = ser.ViewSubjectByLevel(levelId);
                ViewData["Subject"] = new List<SubjectModel>() { new SubjectModel() };
                ViewBag.LoginName = HttpContext.Session.GetString("LoginName");
                return Json(subjects);
            }
            catch (System.Exception)
            {
                return null;
            }
        }

        public IActionResult Delete(string id)
        {

            try
            {
                if (SessionIsNull()) return Redirect("/Home/Login?mustLogin=true&next=/Curriculum/Delete?id="+id);
                PlanService ser = new PlanService();
                int result = ser.DeleteCurriculum(id);
                SetViewBag();
                if(result == 1) return Redirect("/Curriculum/ViewCurriculum?delete_success=true");
                else return Redirect("/Curriculum/ViewCurriculum?delete_error=true");
            }
            catch (System.Exception)
            {
                return Redirect("/Curriculum/ViewCurriculum?delete_error=true");
            }

        }

        [HttpGet]
        public JsonResult DeleteCurriculum2(string id)
        {
            PlanService ser = new PlanService();
            int result = ser.DeleteCurriculum(id);
            SetViewBag();

            return Json(result);
        }

        [HttpGet]
        public JsonResult GetCurriculums()
        {
            PlanService ser = new PlanService();

            SetViewBag();
            if (HttpContext.Session.GetString("RoleName") == "Teacher - Primary")
            {
                IEnumerable<CurriculumModel> models = ser.ViewCurriculum(HttpContext.Session.GetString("EmployeeId"));
                return Json(models);
            }
            else
            {
                IEnumerable<CurriculumModel> models = ser.ViewCurriculum("");
                return Json(models);
            }
        }

        [HttpGet]
        public JsonResult GetCurriculumsPaged(string employeeId,string name,string description,string levelnodeid, int page, int pagesize )
        {
            PlanService ser = new PlanService();

            SetViewBag();
            if (HttpContext.Session.GetString("RoleName") == "Teacher - Primary")
            {
                CurriculumPagedModel models = ser.ViewCurriculumPaged(HttpContext.Session.GetString("EmployeeId"),name, description, levelnodeid, page, pagesize);
                return Json(models);
            }
            else
            {
                CurriculumPagedModel models = ser.ViewCurriculumPaged("", name, description, levelnodeid, page, pagesize);
                return Json(models);
            }
        }

        [HttpGet]
        public JsonResult GetCurriculumDetailsPaged(string curriculumId, int page, int pagesize)
        {
            PlanService ser = new PlanService();

            SetViewBag();
            if (HttpContext.Session.GetString("RoleName") == "Teacher - Primary")
            {
                CurriculumDetailsPagedModel models = ser.ViewCurriculumDetailsPaged(curriculumId, page, pagesize);
                return Json(models);
            }
            else
            {
                CurriculumDetailsPagedModel models = ser.ViewCurriculumDetailsPaged(curriculumId, page, pagesize);
                return Json(models);
            }
        }

        [HttpGet]
        public JsonResult GetLessonsBySubject(string subjectId )
        {
            PlanService ser = new PlanService();
            var lessons = ser.GetLessonModelsBySubject(subjectId);
            SetViewBag();

            return Json(lessons);
        }

        [HttpGet]
        public JsonResult ViewAllCurriculumDetailsByCurriculum(string subjectId,string curriculumId)
        {
            PlanService ser = new PlanService();
            var lessons = ser.ViewAllCurriculumDetailsByCurriculum(subjectId, curriculumId);
            SetViewBag();

            return Json(lessons);
        }

        [HttpGet]
        public JsonResult GetNodesByParent(string parentNodeId)
        {
            PlanService ser = new PlanService();
            var nodes = ser.ViewNodeByParent(parentNodeId);
            SetViewBag();

            return Json(nodes);
        }        

    }
}
