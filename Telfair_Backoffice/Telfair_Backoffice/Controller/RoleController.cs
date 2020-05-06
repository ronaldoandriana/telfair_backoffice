using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Telfair_Backend.Classes.Models;
using Telfair_Backend.Classes.Services;

namespace Telfair_Backend.Controllers
{
    public class RoleController : BaseController
    {
        public IActionResult Role(string error)
        {
            try
            {
                if (SessionIsNull()) return Redirect("/Home/Login?mustLogin=true&next=/Role/Role");
                SetViewBag();
                if (!string.IsNullOrEmpty(error) && error.Equals("true")) SetSavingError();
            }
            catch (System.Exception)
            {
                SetDefaultError();
            }
            return View();
        }

        public IActionResult AccessControl()
        {
            RoleAccessControlModel roleAccessControlModel = new RoleAccessControlModel();
            try
            {
                PlanService service = new PlanService();
                if (SessionIsNull()) return Redirect("/Home/Login?mustLogin=true&next=/Role/AccessControl");
                SetViewBag();
                ViewBag.Roles = new SelectList(service.GetRoles(), "Id", "Name");
                roleAccessControlModel.MenuModels = service.GetMenuByRoleId("");
            }
            catch (System.Exception)
            {
                SetDefaultError();
            }
            return View(roleAccessControlModel);
        }

        public JsonResult GetMenuByRoleId(string roleId)
        {
            try
            {
                List<MenuModel> menuModels = new PlanService().GetMenuByRoleId(roleId);
                return Json(new { Status = 1, Data = menuModels });
            }
            catch (Exception)
            {
                return Json(new { Status = 0, Data = "[]" });
            }
        }
    }
}