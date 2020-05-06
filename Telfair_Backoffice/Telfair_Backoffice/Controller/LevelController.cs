using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using Telfair_Backend.Classes.Services;
using Telfair_Backend.Classes.Models;

namespace Telfair_Backend.Controllers
{
    public class LevelController : BaseController
    {
        public IActionResult Level (string error)
        {
            try
            {
                if (SessionIsNull()) return Redirect("/Home/Login?mustLogin=true&next=/Level/Level");
                PlanService service = new PlanService();
                var nodeTypes = service.GetNodeType();
                ViewBag.NodeType = new SelectList(nodeTypes, "Id", "Name");
                var nodeDepartment = service.ViewNodeByNodeType(StaticData.NODE_DEPARTMENT, int.MaxValue, 1);
                ViewBag.NodeDepartment = new SelectList(nodeDepartment, "Id", "Name");
                SetViewBag();
                if (!string.IsNullOrEmpty(error) && error.Equals("true")) ViewBag.error = "An error occured while saving!";
            }
            catch (Exception)
            {
                ViewBag.error = "An error has occured!";
            }
            return View();
        }

        public IActionResult SaveLevel(NodeModel node)
        {
            try
            {
                PlanService ser = new PlanService();
                node.NodeTypeId = "25da3697-59f4-11e9-8ceb-fb681531b90b";
                int result = ser.SaveNode(node);
                SetViewBag();
                if(result.Equals(1)) return Redirect("/Level/ViewLevel?success=true");
                else return Redirect("/Level/Level?error=true");
            }
            catch (Exception)
            {
                return Redirect("/Level/Level?error=true");
            }
        }

        public ActionResult ViewLevel(string page, string success, string delete_success, string delete_error)
        {
            var levels = new List<NodeModel>();
            try
            {
                if (SessionIsNull()) return Redirect("/Home/Login?mustLogin=true");
                PlanService ser = new PlanService();
                int _page = 1;
                bool isParsed = int.TryParse(page, out _page);
                if (!isParsed || _page <= 0) _page = 1;
                levels = ser.ViewNodeByNodeType("25da3697-59f4-11e9-8ceb-fb681531b90b", 10, _page);
                int nombre = ser.CountLevel("25da3697-59f4-11e9-8ceb-fb681531b90b");
                ViewBag.pagination = new PageUtility().MakePagination(10, nombre, _page, "/Level/ViewLevel?page=");
                ViewData["Level"] = levels;
                SetViewBag();
                if (!string.IsNullOrEmpty(success) && success.Equals("true")) ViewBag.success = "Saving with success!";
                if (!string.IsNullOrEmpty(delete_success) && delete_success.Equals("true")) ViewBag.success = "Deleting with success!";
                if (!string.IsNullOrEmpty(delete_error) && delete_error.Equals("true")) ViewBag.error = "An error has occured while deleting!";
            }
            catch (Exception)
            {
                ViewBag.error = "An error has occured!";
            }
            return View(levels);
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {

            try
            {
                if (SessionIsNull()) return Redirect("/Home/Login?mustLogin=true&next=/Level/Edit?id="+id);
                PlanService ser = new PlanService();
                NodeModel model = ser.GetNodeById(id);

                var nodeDepartment = ser.ViewNodeByNodeType("25da3697-59f4-11e9-8ceb-fb681531b90a", int.MaxValue, 1);
                ViewBag.NodeDepartment = new SelectList(nodeDepartment, "Id", "Name");
                SetViewbagForNodeType();
                SetViewBag();
                return View("Level", model);
            }
            catch (Exception)
            {
                ViewBag.error = "An error has occured!";
                return View("Level");
            }

        }

        public IActionResult Delete(string id)
        {

            try
            {
                if (SessionIsNull()) return Redirect("/Home/Login?mustLogin=true&next=/Level/Delete?id="+id);
                PlanService ser = new PlanService();
                int result = ser.DeleteNode(id);
                SetViewBag();
                if(result == 1) return Redirect("/Level/ViewLevel?delete_success=true");
                else return Redirect("/Level/ViewLevel?delete_error=true");
            }
            catch (Exception)
            {
                return Redirect("/Level/ViewLevel?delete_error=true");
            }

        }

        public void SetViewbagForNodeType()
        {
            PlanService service = new PlanService();
            var nodeType = service.GetNodeType();
            SetViewBag();
            ViewBag.NodeType = new SelectList(nodeType, "Id", "Name");

        }

    
    }
}
