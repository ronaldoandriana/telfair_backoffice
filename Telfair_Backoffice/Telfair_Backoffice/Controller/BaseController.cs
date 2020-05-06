using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.AspNetCore.Http;
using Telfair_Backend.Classes.Services;

namespace Telfair_Backend.Controllers
{
    public class BaseController : Controller
    {
        public void SetViewBag()
        {
            try
            {
                PlanService service = new PlanService();
                var elements = service.GetElementList(HttpContext.Session.GetString("RoleId"));
                ViewBag.Elements = elements;
                ViewBag.LoginName = HttpContext.Session.GetString("LoginName");
                ViewBag.FirstName = HttpContext.Session.GetString("FirstName");
                ViewBag.LastName = HttpContext.Session.GetString("LastName");
                ViewBag.RoleName = HttpContext.Session.GetString("RoleName");
                ViewBag.RoleId = HttpContext.Session.GetString("RoleId");
                ViewBag.EmployeeId = HttpContext.Session.GetString("EmployeeId");
                //ViewBag.Menus = service
            }
            catch (Exception)
            {
                SetDefaultError();
            }

        }

        public bool SessionIsNull()
        {
            return
            string.IsNullOrEmpty(HttpContext.Session.GetString("LoginName")) &&
            string.IsNullOrEmpty(HttpContext.Session.GetString("FirstName")) &&
            string.IsNullOrEmpty(HttpContext.Session.GetString("LastName")) &&
            string.IsNullOrEmpty(HttpContext.Session.GetString("RoleName")) &&
            string.IsNullOrEmpty(HttpContext.Session.GetString("RoleId")) &&
            string.IsNullOrEmpty(HttpContext.Session.GetString("EmployeeId"));
        }

        public void SetDefaultError()
        {
            ViewBag.error = "An error has occured!";
        }

        public void SetSavingError()
        {
            ViewBag.error = "An error has occured while saving!";
        }

        public void SetDeletingError()
        {
            ViewBag.error = "An error has occured while saving!";
        }

        public void SetAllFieldRequiredError()
        {
            ViewBag.error = "All fields are required!";
        }

        public void SetSavingSuccess()
        {
            ViewBag.success = "Saving with success!";
        }

        public void SetDeletingSuccess()
        {
            ViewBag.error = "Deleting with success!";
        }
    }
}