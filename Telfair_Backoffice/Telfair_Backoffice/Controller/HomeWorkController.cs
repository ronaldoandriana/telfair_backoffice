using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using Telfair_Backend.Classes.Services;
using Telfair_Backend.Classes.Entity;
using Telfair_Backend.Classes.Models;

namespace Telfair_Backend.Controllers
{
    public class HomeWorkController : BaseController
    {
        public IActionResult ViewFile(string fileId)
        {
            try
            {
                if (SessionIsNull()) return Redirect("/Home/Login?mustLogin=true&next=/HomeWork/ViewFile?fileId="+fileId);
                SetViewBag();
                PlanService ser = new PlanService();
                string scheme = HttpContext.Request.Scheme;
                string host = HttpContext.Request.Host.ToString();
                string url = scheme + "://" + host;
                ViewBag.url = url;
                Attachments attachments = ser.GetAttachmentById(fileId);
                ViewBag.file = attachments;
                if(attachments != null) ViewBag.relatedFile = ser.GetRelatedFiles(fileId, attachments.IdHomework);
            }
            catch (Exception)
            {

            }
            return View();
        }

        public IActionResult HomeWork (string error,string error_saving_file)
        {
            try
            {
                if (SessionIsNull()) return Redirect("/Home/Login?mustLogin=true&next=/HomeWork/HomeWork");
                SetViewbagForNodeType();
                SetViewBag();
                ViewBag.LoginName = HttpContext.Session.GetString("LoginName");
                PlanService ser = new PlanService();
                var nodeDepartment = ser.ViewNodeByNodeType("25da3697-59f4-11e9-8ceb-fb681531b90a", int.MaxValue, 1);
                ViewBag.NodeDepartment = new SelectList(nodeDepartment, "Id", "Name");
                ViewBag.NodeLevel = new SelectList(new List<NodeModel>(), "Id", "Name");
                ViewBag.Subject = new SelectList(new List<SubjectModel>(), "Id", "Name");
                ViewBag.Actions = new SelectList(ser.GetAllHomeWorkAction(), "Id", "Name");
                if (!string.IsNullOrEmpty(error) && error.Equals("true")) ViewBag.error = "An error has occured while saving!";
                if (!string.IsNullOrEmpty(error_saving_file) && error_saving_file.Equals("true")) ViewBag.error = "An error has occured while saving file(s)!";
            }
            catch (Exception)
            {
                ViewBag.error = "An error has occured!";
            }
            return View();
           
        }

        [HttpPost]
        [DisableRequestSizeLimit]
        public async Task<IActionResult> SaveHomeWork(HomeWorkModel homeWork)
        {
            try
            {
                PlanService ser = new PlanService();
                IFormFileCollection files = Request.Form.Files;
                bool file_saved = await SaveFiles(files);
                if (!file_saved)
                {
                    DeleteFiles(files);
                    return Redirect("/HomeWork/HomeWork?error_saving_file=true");
                }
                homeWork.Attachments = CreateAttachments(files);
                int x = 0;
                if (string.IsNullOrEmpty(homeWork.Id)) x = ser.SaveHomeWork(homeWork);
                else x = ser.UpdateHomeWork(homeWork);
                ViewBag.LoginName = HttpContext.Session.GetString("LoginName");
                if (x == 1) return Redirect("/HomeWork/ViewManage?success=true");
                else return Redirect("/HomeWork/HomeWork?error=true");
            }
            catch (Exception)
            {
                return Redirect("/HomeWork/HomeWork?error=true");
            }
        }

        private List<Attachments> CreateAttachments(IFormFileCollection files)
        {
            List<Attachments> attachments = new List<Attachments>();
            foreach(IFormFile file in files)
            {
                DateTime dt = DateTime.Now;
                string folder = StaticData.FILE_UPLOAD_PATH + "" + dt.Year + "" + dt.Month + "" + dt.Day;
                attachments.Add(new Attachments()
                {
                    Id = Guid.NewGuid().ToString(),
                    FilePath = folder + "/" + file.FileName,
                    FileName = file.FileName,
                    Status = 1,
                    Type = Path.GetExtension(file.FileName).ToLower().Replace(".", "")
                });
            }
            return attachments;
        }

        private void DeleteFiles(IFormFileCollection files)
        {
            try
            {
                foreach (IFormFile file in files)
                {
                    DateTime dt = DateTime.Now;
                    string folder = "wwwroot/" + StaticData.FILE_UPLOAD_PATH + "" + dt.Year + "" + dt.Month + "" + dt.Day;
                    var path = Path.Combine(Directory.GetCurrentDirectory(), folder, file.FileName);
                    if (System.IO.File.Exists(path)) System.IO.File.Delete(path);
                }
            }
            catch (Exception)
            {

            }
        }

        private async Task<Boolean> SaveFiles(IFormFileCollection files)
        {
            try
            {
                foreach(IFormFile file in files)
                {
                    DateTime dt = DateTime.Now;
                    string folder = "wwwroot/" + StaticData.FILE_UPLOAD_PATH + "" + dt.Year + "" + dt.Month + "" + dt.Day;
                    var path = Path.Combine(Directory.GetCurrentDirectory(), folder, file.FileName);
                    string full_folder = Path.Combine(Directory.GetCurrentDirectory(), folder);
                    if (!Directory.Exists(full_folder)) Directory.CreateDirectory(full_folder);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            return false;
        }

        public ActionResult ViewHomeWork(string grade, string page)
        {
            try
            {
                if (SessionIsNull()) return Redirect("/Home/Login?mustLogin=true&next=/HomeWork/ViewHomeWork?grade=" + grade + "&page=" + page);
                SetViewBag();
                PlanService ser = new PlanService();
                int _page = 1;
                bool isParsed = int.TryParse(page, out _page);
                if (!isParsed || _page <= 0) _page = 1;
                ViewBag.homeWorkModels = ser.CompleteFiles(ser.SearchHomeWork(grade, 10, _page));
                int nombre = ser.CountSearchHomeWork(grade);
                ViewBag.pagination = new PageUtility().MakePagination(10, nombre, _page, "/HomeWork/ViewHomeWork?grade=" + grade + "&page=");
                //ViewBag.levels = ser.GetAllLevel();
            }
            catch (Exception)
            {
                ViewBag.error = "An error has occured!";
            }
            return View();
        }

        public ActionResult ViewManage(string page, string success, string delete_success, string delete_error)
        {
            try
            {
                if (SessionIsNull()) return Redirect("/Home/Login?mustLogin=true&next=/HomeWork/ViewManage");
                PlanService ser = new PlanService();
                int _page = 1;
                bool isParsed = int.TryParse(page, out _page);
                if (!isParsed || _page <= 0) _page = 1;
                ViewBag.homeWorkModels = ser.CompleteFiles(ser.GetAllHomeWork(10, _page));
                int nombre = ser.CountAllHomeWork();
                ViewBag.pagination = new PageUtility().MakePagination(10, nombre, _page, "/HomeWork/ViewManage?page=");
                SetViewBag();
                if (!string.IsNullOrEmpty(success) && success.Equals("true")) ViewBag.success = "Saving with success!";
                if (!string.IsNullOrEmpty(delete_success) && delete_success.Equals("true")) ViewBag.success = "Deleting with success!";
                if (!string.IsNullOrEmpty(delete_error) && delete_error.Equals("true")) ViewBag.error = "An error has occured while deleting!";
            }
            catch (Exception)
            {
                ViewBag.error = "An error has occured!";
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            try
            {
                if (SessionIsNull()) return Redirect("/Home/Login?mustLogin=true&next=/HomeWork/Edit?id="+id);
                SetViewbagForNodeType();
                SetViewBag();
                ViewBag.LoginName = HttpContext.Session.GetString("LoginName");
                PlanService ser = new PlanService();
                HomeWorkModel model = ser.GetHomeWorkById(id);
                var nodeDepartment = ser.ViewNodeByNodeType("25da3697-59f4-11e9-8ceb-fb681531b90a", int.MaxValue, 1);
                var nodeLevel = ser.ViewNodeByParent(model.DepartmentNodeId);
                var subject = ser.ViewSubjectByLevel(model.LevelNodeId);
                ViewBag.NodeDepartment = new SelectList(nodeDepartment, "Id", "Name");
                ViewBag.NodeLevel = new SelectList(nodeLevel, "Id", "Name");
                ViewBag.Subject = new SelectList(subject, "Id", "Name");
                ViewBag.Actions = new SelectList(ser.GetAllHomeWorkAction(), "Id", "Name");
                ViewBag.IsEdit = true;
                return View("HomeWork", model);
            }
            catch (Exception)
            {
                return View("HomeWork");
            }

        }

        public JsonResult DeleteFile(string id)
        {
            try
            {
                Attachments x = new PlanService().DeleteFile(id);
                if (x != null)
                {
                    TryDeleteFileServer(x);
                    return Json(new { status = 1, message = "File deleted!" });
                }
                else return Json(new { status = 0, message = "Deleting failed!" });
            }
            catch (Exception)
            {
                return Json(new { status = 0, message = "Deleting failed!" });
            }
        }


        private void TryDeleteFileServer(Attachments file)
        {
            try
            {
                string filename = "wwwroot/" + file.FilePath;
                var path = Path.Combine(Directory.GetCurrentDirectory(), filename);
                if (System.IO.File.Exists(path)) System.IO.File.Delete(path);
            }
            catch (Exception)
            {

            }
        }

        public IActionResult Delete(string id)
        {

            try
            {
                if (SessionIsNull()) return Redirect("/Home/Login?mustLogin=true&next=/HomeWork/Delete?id="+id);
                PlanService ser = new PlanService();
                int result = ser.DeleteHomeWork(id);
                SetViewBag();
                if(result == 1) return Redirect("/HomeWork/ViewManage?delete_success=true");
                else return Redirect("/HomeWork/ViewManage?delete_success=true");
            }
            catch (Exception)
            {
                return Redirect("/HomeWork/ViewManage?delete_error=true");
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
