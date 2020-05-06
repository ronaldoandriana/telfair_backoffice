using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using Telfair_Backend.Classes.Services;
using Telfair_Backend.Classes.Models;

namespace Telfair_Backend.Controllers
{
    public class SubjectController : BaseController
    {
        public IActionResult Subject(string error, string emptyfield)
        {
            ViewBag.title = "Add new subject";
            try
            {
                if (SessionIsNull()) return Redirect("/Home/Login?mustLogin=true&next=/Subject/Subject");
                PlanService ser = new PlanService();
                var nodeDepartment = ser.ViewNodeByNodeType("25da3697-59f4-11e9-8ceb-fb681531b90a", int.MaxValue, 1);
                ViewBag.NodeDepartment = new SelectList(nodeDepartment, "Id", "Name");
                ViewBag.NodeLevel = new SelectList(new List<NodeModel>(), "Id", "Name");
                SetViewBag();
                if (!string.IsNullOrEmpty(error) && error.Equals("true")) SetSavingError();
                if (!string.IsNullOrEmpty(emptyfield) && emptyfield.Equals("true")) SetAllFieldRequiredError();
            }
            catch (Exception)
            {
                SetDefaultError();
            }
            return View();
        }

        public IActionResult SaveSubject(SubjectModel subject)
        {
            try
            {
                PlanService ser = new PlanService();
                int result = ser.SaveSubject(subject);
                SetViewBag();
                if(hasEmptyValue(subject)) return Redirect("/Subject/Subject?emptyfield=true");
                if (result == 1) return Redirect("/Subject/ViewSubject?success=true");
                else return Redirect("/Subject/Subject?error=true");
            }
            catch (Exception)
            {
                return Redirect("/Subject/Subject?error=true");
            }
        }

        public ActionResult ViewSubject(string page, string success, string delete_success, string delete_error)
        {
            var subjects = new List<SubjectModel>();
            try
            {
                if (SessionIsNull()) return Redirect("/Home/Login?mustLogin=true&next=/Subject/ViewSubject");
                PlanService ser = new PlanService();
                int _page = 1;
                bool isParsed = int.TryParse(page, out _page);
                if (!isParsed || _page <= 0) _page = 1;
                subjects = ser.ViewSubject(10, _page);
                int nombre = ser.CountSubject();
                ViewBag.pagination = new PageUtility().MakePagination(10, nombre, _page, "/Subject/ViewSubject?page=");
                ViewData["Subject"] = subjects;
                SetViewBag();
                if (!string.IsNullOrEmpty(success) && success.Equals("true")) ViewBag.success = "Saving with success!";
                if (!string.IsNullOrEmpty(delete_success) && delete_success.Equals("true")) ViewBag.success = "Deleting with success!";
                if (!string.IsNullOrEmpty(delete_error) && delete_error.Equals("true")) ViewBag.error = "An error has occured while deleting!";
            }
            catch (Exception)
            {
                ViewBag.error = "An error has occured";
            }
            return View(subjects);
        }

        public JsonResult ViewSubjectByLevel(string levelId)
        {
            try
            {
                PlanService ser = new PlanService();
                var subjects = ser.ViewSubjectByLevel(levelId);
                ViewData["Subject"] = new List<SubjectModel>() { new SubjectModel() };
                //SetViewBag();
                return Json(subjects);
            }
            catch (Exception)
            {
                return null;
            }
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            ViewBag.title = "Edit subject";
            try
            {
                if (SessionIsNull()) return Redirect("/Home/Login?mustLogin=true&next=/Subject/Edit?id="+id);
                PlanService ser = new PlanService();
                SubjectModel model = ser.GetSubjectById(id);
                var nodeDepartment = ser.ViewNodeByNodeType("25da3697-59f4-11e9-8ceb-fb681531b90a", int.MaxValue, 1);
                var nodeLevel = ser.ViewNodeByParent(model.DepartmentNodeId);

                ViewBag.NodeDepartment = new SelectList(nodeDepartment, "Id", "Name");
                ViewBag.NodeLevel = new SelectList(nodeLevel, "Id", "Name");
                SetViewBag();
                return View("Subject", model);
            }
            catch (Exception)
            {
                ViewBag.error = "An error has occured!";
                return View("Subject");
            }
        }

        public IActionResult Delete(string id)
        {
            try
            {
                if (SessionIsNull()) return Redirect("/Home/Login?mustLogin=true&next=/Subject/Delete?id="+id);
                PlanService ser = new PlanService();
                int result = ser.DeleteSubject(id);
                SetViewBag();
                if(result == 1) return Redirect("/Subject/ViewSubject?delete_success=true");
                else return Redirect("/Subject/ViewSubject?delete_error=true");
            }
            catch (Exception)
            {
                return Redirect("/Subject/ViewSubject?delete_error=true");
            }
        }

        private bool hasEmptyValue(SubjectModel subjectModel)
        {
            try
            {
                return string.IsNullOrEmpty(subjectModel.DepartmentNodeId) ||
                       string.IsNullOrEmpty(subjectModel.Description) ||
                       string.IsNullOrEmpty(subjectModel.LevelNodeId) ||
                       string.IsNullOrEmpty(subjectModel.Name);
            }
            catch (Exception)
            {
                return true;
            }
        }

    }
}
