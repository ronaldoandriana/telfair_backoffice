using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using SAIM.Core.Data;
using Telfair_Backend.Classes.Services;
using Telfair_Backend.Classes.Models;

namespace Telfair_Backend.Controllers
{
    public class DepartmentController : BaseController
    {
        public JsonResult LoadGrade()
        {
            try
            {
                string parentId = HttpContext.Session.GetString("EmployeeId");
                if(string.IsNullOrEmpty(parentId))
                {
                    return Json(new { status = 0, message = "You are not connected, try to reload this page!" });
                }
                else
                {
                    PlanService service = new PlanService();
                    Person p = service.GetPersonByEmployeeId(parentId);
                    List<ParentChildrenNodeModel> models = service.GetParentChildrenNodeModelByEmplyeeId(p.Id);
                    return Json(new { Status = 1, message = "Success!", data = models });
                }
            }
            catch (Exception)
            {
                return Json(new { Status = 0, message = "An error has occured!" });
            }
        }

        public JsonResult LoadDepartmentAndGrade()
        {
            try
            {
                PlanService service = new PlanService();
                List<NodeModel> departments = service.ViewNodeByNodeType(StaticData.NODE_DEPARTMENT, int.MaxValue, 1);
                List<DepartmentModel> departmentModels = service.GetDepartmentModel(departments);
                return Json(new { Status = 1, message = "Success!", data = departmentModels });
            }
            catch (Exception)
            {
                return Json(new { Status = 0, message = "An error has occured!" });
            }
        }
        public IActionResult Department (string error)
        {
            try
            {
                if (SessionIsNull()) return Redirect("/Home/Login?mustLogin=true&next=/Department/Department");
                SetViewbagForNodeType();
                SetViewBag();
                ViewBag.LoginName = HttpContext.Session.GetString("LoginName");
                if(!string.IsNullOrEmpty(error) && error.Equals("true")) ViewBag.error = "An error has occurred while saving!";
            }
            catch (Exception)
            {
                SetDefaultError();
            }
            return View();
        }

        public IActionResult SaveDepartment(NodeModel node)
        {
            try
            {
                PlanService ser = new PlanService();
                node.NodeTypeId = "25da3697-59f4-11e9-8ceb-fb681531b90a";
                int result = ser.SaveNode(node);
                ViewBag.LoginName = HttpContext.Session.GetString("LoginName");
                if(result.Equals(1)) return Redirect("/Department/ViewDepartment?success=true");
                else return Redirect("/Department/Department?error=true");
            }
            catch (Exception)
            {
                return Redirect("/Department/Department?error=true");
            }
        }

        public ActionResult ViewDepartment(string page, string success, string error, string delete_success, string delete_error)
        {
            var departments = new List<NodeModel>();
            try
            {
                if (SessionIsNull()) return Redirect("/Home/Login?mustLogin=true&next=/Department/ViewDepartment");
                PlanService ser = new PlanService();
                int _page = 1;
                bool isParsed = int.TryParse(page, out _page);
                if (!isParsed || _page <= 0) _page = 1;
                departments = ser.ViewNodeByNodeType("25da3697-59f4-11e9-8ceb-fb681531b90a", 10, _page);
                int nombre = ser.CountLevel("25da3697-59f4-11e9-8ceb-fb681531b90a");
                ViewBag.pagination = new PageUtility().MakePagination(10, nombre, _page, "/Department/ViewDepartment?page=");
                if (!string.IsNullOrEmpty(success) && success.Equals("true")) ViewBag.success = "Saving with success!";
                if (!string.IsNullOrEmpty(error) && error.Equals("true")) ViewBag.error = "An error has occured!";
                if (!string.IsNullOrEmpty(delete_success) && delete_success.Equals("true")) ViewBag.success = "Deleting with success!";
                if (!string.IsNullOrEmpty(delete_error) && delete_error.Equals("true")) ViewBag.error = "An error has occured while deleting!";
                SetViewBag();
                ViewData["Department"] = departments;
            }
            catch (Exception)
            {
                ViewBag.error = "An error has occured!";
            }
            return View(departments);
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {

            try
            {
                if (SessionIsNull()) return Redirect("/Home/Login?mustLogin=true&next=/Department/Edit?id="+id);
                PlanService ser = new PlanService();
                NodeModel model = ser.GetNodeById(id);
                SetViewbagForNodeType();
                SetViewBag();
                return View("Department", model);
            }
            catch (Exception)
            {
                ViewBag.error = "An error has occured!";
                return View("Department");
            }
        }

        public IActionResult Delete(string id)
        {

            try
            {
                if (SessionIsNull()) return Redirect("/Home/Login?mustLogin=true&next=/Department/Delete?id="+id);
                PlanService ser = new PlanService();
                int result = ser.DeleteNode(id);
                SetViewBag();
                if(result.Equals(1)) return Redirect("/Department/ViewDepartment?delete_success=true");
                else return Redirect("/Department/ViewDepartment?delete_error=true");
            }
            catch (Exception)
            {
                return Redirect("/Department/ViewDepartment?error=true");
            }

        }



        public void SetViewbagForNodeType()
        {
            PlanService service = new PlanService();
            var nodeType = service.GetNodeType();
            ViewBag.LoginName = HttpContext.Session.GetString("LoginName");
            ViewBag.NodeType = new SelectList(nodeType, "Id", "Name");

        }     

    }
}
