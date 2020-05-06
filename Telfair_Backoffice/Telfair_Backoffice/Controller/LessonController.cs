using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using Telfair_Backend.Classes.Services;
using Telfair_Backend.Classes.Models;

namespace Telfair_Backend.Controllers
{
    public class LessonController : BaseController
    {
        public IActionResult Lesson (string error)
        {
            try
            {
                if (SessionIsNull()) return Redirect("/Home/Login?mustLogin=true&next=/Lesson/Lesson");
                PlanService ser = new PlanService();
                var nodeDepartment = ser.ViewNodeByNodeType("25da3697-59f4-11e9-8ceb-fb681531b90a", int.MaxValue, 1);
                ViewBag.NodeDepartment = new SelectList(nodeDepartment, "Id", "Name");
                ViewBag.NodeLevel = new SelectList(new List<NodeModel>(), "Id", "Name");
                ViewBag.Subject = new SelectList(new List<SubjectModel>(), "Id", "Name");
                SetViewBag();
                if (!string.IsNullOrEmpty(error) && error.Equals("true")) ViewBag.error = "An error has occured while saving!";
            }
            catch (Exception)
            {
                ViewBag.error = "An error has occured!";
            }
            return View();
        }

        public JsonResult AddObjectives(string name, string description, string subjectid)
        {
            try
            {
                LessonModel lesson = new LessonModel()
                {
                    Name = name,
                    Description = description,
                    SubjectId = subjectid
                };
                PlanService ser = new PlanService();
                int result = ser.SaveLesson(lesson);
                if (result == 1) return Json(new { status = 1, message = "Activity has been added!" });
                else return Json(new { status = 0, message = "An error has occured while saving!" });
            }
            catch (Exception)
            {
                return Json(new { status = 0, message = "An error has occured!"});
            }
        }

        public IActionResult SaveLesson(LessonModel lesson)
        {
            try
            {
                PlanService ser = new PlanService();
                int result = ser.SaveLesson(lesson);
                SetViewBag();
                if(result == 1) return Redirect("/Lesson/ViewLesson?success=true");
                else return Redirect("/Lesson/Lesson?error=true");
            }
            catch (Exception)
            {
                return Redirect("/Lesson/Lesson?error=true");
            }
        }

        public ActionResult ViewLesson(string page, string success, string delete_success, string delete_error)
        {
            var lesson = new List<LessonModel>();
            try
            {
                if (SessionIsNull()) return Redirect("/Home/Login?mustLogin=true&next=/Lesson/ViewLesson");
                PlanService ser = new PlanService();
                int _page = 1;
                bool isParsed = int.TryParse(page, out _page);
                if (!isParsed || _page <= 0) _page = 1;
                lesson = ser.ViewLesson(10, _page);
                int nombre = ser.CountLesson();
                ViewBag.pagination = new PageUtility().MakePagination(10, nombre, _page, "/Lesson/ViewLesson?page=");
                ViewData["Lessons"] = lesson;
                SetViewBag();
                if (!string.IsNullOrEmpty(success) && success.Equals("true")) ViewBag.success = "Saving with success!";
                if (!string.IsNullOrEmpty(delete_success) && delete_success.Equals("true")) ViewBag.success = "Deleting with success!";
                if (!string.IsNullOrEmpty(delete_error) && delete_error.Equals("true")) ViewBag.error = "An error has occured while deleting!";
            }
            catch (Exception)
            {
                ViewBag.error = "An error has occured!";
            }
            return View(lesson);
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            try
            {
                if (SessionIsNull()) return Redirect("/Home/Login?mustLogin=true&next=/Lesson/Edit?id="+id);
                PlanService ser = new PlanService();
                LessonModel model = ser.GetLessonById(id);
                var nodeDepartment = ser.ViewNodeByNodeType("25da3697-59f4-11e9-8ceb-fb681531b90a", int.MaxValue, 1);
                var nodeLevel = ser.ViewNodeByParent(model.DepartmentNodeId);
                var subject = ser.ViewSubjectByLevel(model.LevelNodeId);

                ViewBag.NodeDepartment = new SelectList(nodeDepartment, "Id", "Name");
                ViewBag.NodeLevel = new SelectList(nodeLevel, "Id", "Name");
                ViewBag.Subject = new SelectList(subject, "Id", "Name");
                SetViewBag();
                return View("Lesson", model);
            }
            catch (Exception)
            {
                ViewBag.error = "An error has occured!";
                return View("Lesson");
            }
        }

        public IActionResult Delete(string id)
        {

            try
            {
                if (SessionIsNull()) return Redirect("/Home/Login?mustLogin=true&next=/Lesson/Delete?id="+id);
                PlanService ser = new PlanService();
                int result = ser.DeleteLesson(id);
                SetViewBag();
                if(result == 1) return Redirect("/Lesson/ViewLesson?delete_success=true");
                else return Redirect("/Lesson/ViewLesson?delete_error=true");
            }
            catch (Exception)
            {
                return Redirect("/Lesson/ViewLesson?delete_error=true");
            }

        }

        [HttpGet]
        public JsonResult GetNodesByParent(string parentNodeId)
        {
            try
            {
                PlanService ser = new PlanService();
                var nodes = ser.ViewNodeByParent(parentNodeId);
                SetViewBag();
                return Json(nodes);
            }
            catch (Exception)
            {
                return null;
            }
        }

    }
}
