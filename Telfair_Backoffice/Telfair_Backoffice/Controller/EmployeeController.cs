using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using Telfair_Backend.Classes.Models;
using Telfair_Backend.Classes.Services;

namespace Telfair_Backend.Controllers
{
    public class EmployeeController : BaseController
    {
        public IActionResult Employee(string error)
        {
            var model = new EmployeeModel();
            try
            {
                if (SessionIsNull()) return Redirect("/Home/Login?mustLogin=true&next=/Employee/Employee");
                PlanService service = new PlanService();
                SetViewBag();
                ViewBag.Roles = new SelectList(new PlanService().GetRoles(), "Id", "Name");
                model = new EmployeeModel();
                model.EmployeeSubjects = service.GetEmployeeSubjects("");
                ViewBag.Grades = service.GetParentChildrenNodeModels("");
                if (!string.IsNullOrEmpty(error) && error.Equals("true")) SetSavingError();
            }
            catch (System.Exception)
            {
                SetDefaultError();
            }
            return View(model);
        }

        public JsonResult GetGrades()
        {
            try
            {
                var grades = new PlanService().ViewNodeByNodeType(StaticData.NODE_GRADE, int.MaxValue, 1);
                return Json(new { status = 1, message = "success", data = grades });
            }
            catch (System.Exception)
            {
                return Json(new { status = 0, message = "An error has occured!"});
            }
        }

        //[HttpGet]
        public ActionResult ViewEmployee(string name, string page, string success, string delete_success, string delete_error)
        {
            var employee = new List<EmployeeModel>();
            try
            {
                if (SessionIsNull()) return Redirect("/Home/Login?mustLogin=true&&next=/Employee/ViewEmployee?name="+name+"&page="+page);
                PlanService ser = new PlanService();
                int _page = 1;
                bool isParsed = int.TryParse(page, out _page);
                if (!isParsed || _page <= 0) _page = 1;
                employee = ser.GetAllEmployees(name, 10, _page);
                int nombre = ser.CountAllEmployees(name);
                ViewBag.name = name;
                ViewBag.pagination = new PageUtility().MakePagination(10, nombre, _page, "/Employee/ViewEmployee?name=" + name + "&page=");
                ViewBag.Roles = new SelectList(new PlanService().GetRoles(), "Id", "Name");

                SetViewBag();
                if (!string.IsNullOrEmpty(success) && success.Equals("true")) ViewBag.success = "Saving with success!";
                if (!string.IsNullOrEmpty(delete_success) && delete_success.Equals("true")) ViewBag.success = "Deleting with success!";
                if (!string.IsNullOrEmpty(delete_error) && delete_error.Equals("true")) ViewBag.error = "An error has occured while deleting!";
            }
            catch (System.Exception)
            {
                ViewBag.error = "An error has occured!";
            }
            return View(employee);
        }

        public IActionResult SaveEmployee(EmployeeModel employee)
        {
            try
            {
                PlanService ser = new PlanService();
                int result = ser.SaveEmployeeUserRole(employee);
                SetViewBag();
                if (result == 1)
                    return Redirect("/Employee/ViewEmployee?success=true");
                else
                    return Redirect("/Employee/Employee?error=true");
            }
            catch (System.Exception)
            {
                return Redirect("/Employee/Employee?error=true");
            }

        }

        public ActionResult Edit(string id)
        {
            try
            {
                if (SessionIsNull()) return Redirect("/Home/Login?mustLogin=true&next=/Employee/Edit/"+id);
                PlanService ser = new PlanService();
                EmployeeModel model = new EmployeeModel();
                model = ser.GetEmployeeUserRole(id)[0];
                SetViewBag();
                ViewBag.Roles = new SelectList(new PlanService().GetRoles(), "Id", "Name");
                model.EmployeeSubjects = ser.GetEmployeeSubjects(model.Id);
                ViewBag.Grades = ser.GetParentChildrenNodeModels(id);
                ViewBag.isEdit = true;
                return View("Employee", model);
            }
            catch (System.Exception)
            {
                ViewBag.error = "An error has occured!";
                return View("Employee");
            }
        }

        public IActionResult Delete(string id)
        {

            try
            {
                if (SessionIsNull()) return Redirect("/Home/Login?mustLogin=true&next=/Employee/Delete?id="+id);
                PlanService ser = new PlanService();
                int result = ser.DeleteUser(id);
                SetViewBag();
                if(result == 1) return Redirect("/Employee/ViewEmployee?delete_success=true");
                else return Redirect("/Employee/ViewEmployee?delete_error=true");
            }
            catch (System.Exception)
            {
                return Redirect("/Employee/ViewEmployee?delete_error=true");
            }
        }

    }
}
