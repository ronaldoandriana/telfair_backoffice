using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Text;
using System.IO;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Telfair_Backend.Classes.Services;
using Telfair_Backend.Classes.Models;

namespace Telfair_Backend.Controllers
{
    
    public class PlanController : BaseController
    {
        private int duration = 0;

        public IActionResult Index ()
        {
            SetViewBag();
            return View();
        }

        public IActionResult Privacy()
        {
            SetViewBag();
            return View();
        }

        public IActionResult Plan(string error)
        {
            try
            {
                if (SessionIsNull()) return Redirect("/Home/Login?mustLogin=true&next=/Plan/Plan");
                PlanService service = new PlanService();
                SetViewBag();
                var nodeLevelType = HttpContext.Session.GetString("RoleName").ToLower() == "teacher - primary"
                    ? service.ViewNodeBySubject("25da3697-59f4-11e9-8ceb-fb681531b90b", HttpContext.Session.GetString("EmployeeId"))
                    : HttpContext.Session.GetString("RoleName").ToLower() == "administrator"
                        ? service.ViewNodeByNodeType("25da3697-59f4-11e9-8ceb-fb681531b90b", int.MaxValue, 1)
                        : new List<NodeModel>();

                var planTypes = service.GetPlanTypes();
                var days = new List<Days>() { new Days() {Id = 1, Name =  "Monday" }, new Days() { Id = 2, Name = "Tuesday" }, new Days() { Id =3, Name = "Wednesday" },
                new Days() { Id =4,Name =  "Thursday" }, new Days() { Id = 5,Name = "Friday" } };
                ViewBag.NodeLevelType = new SelectList(nodeLevelType, "Id", "Name");
                ViewBag.Subject = new SelectList(new List<SubjectModel>(), "Id", "Name");
                ViewBag.Employee = new SelectList(new List<EmployeeModel>(), "Id", "FullName");
                ViewBag.Lesson = new SelectList(new List<LessonModel>(), "Id", "Name");
                ViewBag.PlanType = new SelectList(planTypes, "Id", "Name");
                ViewBag.Day = new SelectList(days, "Id", "Name");
                var model = new PlanModel() { DateOfIssue = DateTime.Now };
                if (!string.IsNullOrEmpty(error) && error.Equals("true")) ViewBag.error = "An error has occured while saving!";
                return View(model);
            }
            catch (Exception)
            {
                ViewBag.error = "An error has occured!";
                var model = new PlanModel() { DateOfIssue = DateTime.Now };
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            if (SessionIsNull()) return Redirect("/Home/Login?mustLogin=true&next=/Plan/Edit?id="+id);
            PlanService service = new PlanService();
            var planModel = service.GetPlanById(id);
            var nodeLevelType = HttpContext.Session.GetString("RoleName").ToLower() == "teacher - primary"
               ? service.ViewNodeBySubject
               (StaticData.NODE_GRADE, HttpContext.Session.GetString("EmployeeId"))
               : HttpContext.Session.GetString("RoleName").ToLower() == "administrator"
                   ? service.ViewNodeByNodeType(StaticData.NODE_GRADE, int.MaxValue, 1)
                   : new List<NodeModel>();

            //var employees = HttpContext.Session.GetString("LoginName").ToLower() == "parvesh@gmail.com"
            //    ? service.GetEmployees(HttpContext.Session.GetString("LoginName").ToLower()) 
            //    : service.GetEmployees();



            var employees = service.GetEmployeesBySubject(planModel.SubjectId);




            var planTypes = service.GetPlanTypes();
            var days = new List<Days>() { new Days() {Id = 1, Name =  "Monday" }, new Days() { Id = 2, Name = "Tuesday" }, new Days() { Id =3, Name = "Wednesday" },
                new Days() { Id =4,Name =  "Thursday" }, new Days() { Id = 5,Name = "Friday" } };
            var subjects = service.ViewSubjectByLevel(planModel.NodeLevelId);
            var lessons = service.GetLessonModelsBySubject(planModel.SubjectId);
            ViewBag.NodeLevelType = new SelectList(nodeLevelType, "Id", "Name");
            ViewBag.Subject = new SelectList(subjects, "Id", "Name");
            ViewBag.Employee = new SelectList(employees, "Id", "FullName");
            ViewBag.Lesson = new SelectList(lessons, "Id", "Name");
            ViewBag.PlanType = new SelectList(planTypes, "Id", "Name");
            ViewBag.Day = new SelectList(days, "Id", "Name");
            SetViewBag();
            return View("Plan",planModel);
        }

        //public IActionResult SavePlan()
        //{
        //    SetViewBag();
        //    return View();
        //}

        [HttpPost]
        public IActionResult SavePlan(PlanModel plan)
        {
            try
            {
                PlanService ser = new PlanService();
                int result = ser.SavePlan(plan);
                SetViewBag();
                if (result == 1) return Redirect("/Plan/ViewMyPlan?success=true");
                else return Redirect("/Plan/Plan?error=true");
            }
            catch (Exception)
            {
                return Redirect("/Plan/Plan?error=true");
            }            
        }

        public ActionResult ViewPlan(string page, string success, string delete_success, string delete_error)
        {
            var plans = new List<PlanModel>();
            try
            {
                if (SessionIsNull()) return Redirect("/Home/Login?mustLogin=true&next=/Plan/ViewPlan");
                PlanService ser = new PlanService();
                int _page = 1;
                bool isParsed = int.TryParse(page, out _page);
                if (!isParsed || _page <= 0) _page = 1;
                plans = ser.ViewPlan(10, _page);
                int nombre = ser.CountPlan();
                ViewBag.pagination = new PageUtility().MakePagination(10, nombre, _page, "/Plan/ViewPlan?page=");
                ViewData["Plan"] = plans;
                SetViewBag();
                if (!string.IsNullOrEmpty(success) && success.Equals("true")) ViewBag.success = "Saving with success!";
                if (!string.IsNullOrEmpty(delete_success) && delete_success.Equals("true")) ViewBag.success = "Deleting with success!";
                if (!string.IsNullOrEmpty(delete_error) && delete_error.Equals("true")) ViewBag.error = "An error has occured while deleting!";
                return View(plans);
            }
            catch (Exception)
            {
                ViewBag.error = "An error has occured!";
                return View(plans);
            }

        }

        public ActionResult ViewMyPlan(string page, string success, string delete_success, string delete_error)
        {
            var plans = new List<PlanSummaryModel>();
            try
            {
                if (SessionIsNull()) return Redirect("/Home/Login?mustLogin=true&next=/Plan/ViewMyPlan");
                PlanService ser = new PlanService();
                SetViewBag();
                var employeeId = ViewBag.EmployeeId;
                if (ViewBag.RoleName == "Administrator")
                    employeeId = "1";
                int _page = 1;
                bool isParsed = int.TryParse(page, out _page);
                if (!isParsed || _page <= 0) _page = 1;
                int nombre = ser.CountPlanSummaryByEmployeeId(employeeId);
                plans = ser.GetPlanSummaryByEmployeeId(employeeId, 10, _page, duration);
                ViewBag.pagination = new PageUtility().MakePagination(10, nombre, _page, "/Plan/ViewMyPlan?page=");
                if (!string.IsNullOrEmpty(success) && success.Equals("true")) ViewBag.success = "Saving with success!";
                if (!string.IsNullOrEmpty(delete_success) && delete_success.Equals("true")) ViewBag.success = "Deleting with success!";
                if (!string.IsNullOrEmpty(delete_error) && delete_error.Equals("true")) ViewBag.error = "An error has occured while deleting!";
                return View(plans);
            }
            catch (Exception)
            {
                ViewBag.error = "An error has occured!";
                return View(plans);
            }

        }

        [HttpGet]
        public JsonResult ViewMyWeeklyPlans(string subjectId,string employeeId,int term, int week)
        {
            try
            {
                PlanService ser = new PlanService();
                var plans = ser.GetWeeklyPlanBySubjectAndEmployee(subjectId, employeeId, term, week, 0);

                return Json(plans);
            }
            catch (Exception)
            {
                return null;
            }

        }

        [HttpGet]
        public ActionResult ViewMyWeeklyPlansDetails(string planId)
        {
            try
            {
                PlanService ser = new PlanService();
                var planModel = ser.GetPlanById(planId);
                var plans = ser.GetWeeklyPlanBySubjectAndEmployee(planModel.SubjectId, planModel.EmployeeIds, planModel.Term, planModel.Week, planModel.Duration);
                //ViewData["Plan"] = plans;
                SetViewBag();

                if (planModel.NodeDepartmentId != "f67af242-1f0a-4bae-9152-39d30e9e6c6b")
                {
                    return View("ViewMyPlanDetails", plans);
                }
                else
                {
                    return View("ViewMyPlanDetailsNursery", plans);
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        [HttpGet]
        public ActionResult ViewMyWeeklyPlansDetailsPrint(string planId)
        {
            PlanService ser = new PlanService();
            var planModel = ser.GetPlanById(planId);
            var plans = ser.GetWeeklyPlanBySubjectAndEmployee(planModel.SubjectId, planModel.EmployeeIds, planModel.Term, planModel.Week, planModel.Duration);
            //ViewData["Plan"] = plans;
            SetViewBag();

            if (planModel.NodeDepartmentId != "f67af242-1f0a-4bae-9152-39d30e9e6c6b")
            {
                return View("ViewMyPlanDetailsPrint", plans);
            }
            else
            {
                return View("ViewMyPlanDetailsNurseryPrint", plans);
            }
        }

        [HttpGet]
        public ActionResult ViewMyPlanDetails(string id)
        {
            PlanService ser = new PlanService();
            var plans = ser.GetPlanBySubjectId(id);
            //ViewData["Plan"] = plans;
            SetViewBag();
            return View(plans);

        }

        [HttpGet]
        public ActionResult ViewMyPlanDetailsPrint(string id)
        {
            PlanService ser = new PlanService();
            var plans = ser.GetPlanBySubjectId(id);
            //ViewData["Plan"] = plans;
            SetViewBag();
            return View(plans);

        }

        //[HttpGet]
        //public ActionResult ViewMyPlanDetailsNurseryPrint(string id)
        //{
        //    PlanService ser = new PlanService();
        //    var plans = ser.GetPlanBySubjectId(id);
        //    //ViewData["Plan"] = plans;
        //    SetViewBag();
        //    return View(plans);

        //}

        [HttpGet]
        public ActionResult ViewMyPlanDetailsNurseryPrint(string id)
        {
            PlanService ser = new PlanService();
            var planModel = ser.GetPlanById(id);
            var plans = ser.GetWeeklyPlanBySubjectAndEmployee(planModel.SubjectId, planModel.EmployeeIds, planModel.Term, planModel.Week, planModel.Duration);
            //ViewData["Plan"] = plans;
            SetViewBag();

            if (planModel.NodeDepartmentId != "f67af242-1f0a-4bae-9152-39d30e9e6c6b")
            {
                return View("ViewMyPlanDetailsNurseryPrint", plans);
            }
            else
            {
                return View("ViewMyPlanDetailsNurseryPrint", plans);
            }

        }



        [HttpGet]
        public ActionResult ViewMyPlanDetailsNursery(string id)
        {
            PlanService ser = new PlanService();
            var plans = ser.GetPlanBySubjectId(id);
            //ViewData["Plan"] = plans;
            SetViewBag();
            return View(plans);

        }

        [HttpGet]
        public ActionResult ViewMyPlanDetailsDecision(string id)
        {
            PlanService ser = new PlanService();
            var plans = ser.GetPlanBySubjectId(id);
            //ViewData["Plan"] = plans;
            SetViewBag();

            if (HttpContext.Session.GetString("LoginName").ToLower() == "cheila@gmail.com"|| id == "40ff5b91-3ce7-4122-a5de-3907f86c6630")
            {
                return RedirectToAction("ViewMyPlanDetailsNursery", new { id });
            }
            else
            {
                return RedirectToAction("ViewMyPlanDetails", new {  id });
            }
        }

        public ActionResult EditProduct(string id)
        {
            if (SessionIsNull()) return Redirect("/Home/Login?mustLogin=true&next=/Plan/EditProduct?id="+id);
            PlanService ser = new PlanService();
            PlanModel model = ser.GetPlanById(id);
            SetViewBag();
            return View("Plan",model);

        }

        public ActionResult Delete(string id)
        {
            try
            {
                if (SessionIsNull()) return Redirect("/Home/Login?mustLogin=true&next=/Plan/Delete?id="+id);
                PlanService ser = new PlanService();
                int result = ser.DeletePlan(id);
                SetViewBag();
                if (result == 1) return Redirect("/Plan/ViewMyPlan?delete_success=true");
                else return Redirect("/Plan/ViewMyPlan?delete_error=true");


            }
            catch (System.Exception)
            {
                return Redirect("/Plan/ViewMyPlan?delete_error=true");
            }
        }

        public IActionResult BuildPDF(string PdfHtmlTemplate )
        {
            //HtmlLoadOptions objLoadOptions = new HtmlLoadOptions();
            //objLoadOptions.PageInfo.Margin.Bottom = 10;
            //objLoadOptions.PageInfo.Margin.Top = 20;

            ////Load HTML string into MemoryStream using Aspose document class
            //Document doc = new Document(new MemoryStream(Encoding.UTF8.GetBytes(PdfHtmlTemplate)), objLoadOptions);
            //string FileName = "Compilemode_" + DateTime.Now.ToString("dd-MM-yyyy") + ".pdf";
            ////Save PDF file on local hard drive or database or as you wish          
            //doc.Save("C:\\Test\\" + FileName);
            SetViewBag();
            return View();
        }

        [HttpGet]
        public JsonResult BuildIronPDF(string Html)
        {
            // Render any HTML fragment or document to HTML
            ////var Renderer = new IronPdf.HtmlToPdf();
            ////var PDF = Renderer.RenderHtmlAsPdf("<h1>Hello IronPdf</h1>");
            ///var OutputPath = "HtmlToPDF.pdf";
            //PDF.SaveAs(OutputPath);
            // This neat trick opens our PDF file so we can see the result in our default PDF viewer
            //System.Diagnostics.Process.Start(OutputPath);
            PlanService ser = new PlanService();
            //string s = View(ser.ViewPlan(int.MaxValue, 1)).ToString();
            //ViewData["Plan"] = ser.ViewPlan(int.MaxValue, 1);

            //IronPdf.HtmlToPdf Renderer = new IronPdf.HtmlToPdf();
            //// Render an HTML document or snippet as a string
            ////Renderer.RenderHtmlAsPdf("<table class=\"table\"><tbody><tr><th>Lesson Title</th><th>Aims</th><th>Activities</th><th>Materials</th><th>Method</th><th>OutcomesNotes</th><th></th></tr><tr><td>Lesson1</td><td>Aims1</td><td>Activities1</td><td>Materials1</td><td>Method1</td><td>OutcomesNotes1</td></tr><tr><td>Lesson2</td><td>Aims2-</td><td>Activities2</td><td>Materials2</td><td>Method2</td><td>OutcomesNotes2</td></tr><tr><td>Lesson3</td><td>Aims3</td><td>Activities3</td><td>Materials3</td><td>Method3</td><td>OutcomesNotes3</td></tr></tbody></table>").SaveAs("C:/Test/html-string.pdf");
            //Renderer.RenderHtmlAsPdf("<p>Test</p>").SaveAs("html-string.pdf");
            ////Renderer.RenderHtmlAsPdf(Html).SaveAs("C:/Test/html-string.pdf");
            //// Advanced: 
            //// Set a "base url" or file path so that images, javascript and CSS can be loaded  
            //var PDF = Renderer.RenderHtmlAsPdf("<img src='icons/test.png'>", @"C:/Test");
            //PDF.SaveAs("C:/Test/html-with-assets.pdf");

           // SetViewBag();
            //return View();
            return Json(ser.ViewPlan(int.MaxValue, 1));
        }

        [HttpGet]
        public JsonResult GetEmployeesBySubject(string id)
        {
            PlanService ser = new PlanService();
            return Json(ser.GetEmployeesBySubject(id));
        }

        public IActionResult BuildIronPDFURL(string PdfHtmlTemplate)
        {
            //var uri = new Uri("https://localhost:44304/BackOffice/Plan/ViewMyPlanDetailsPrint/g0b74728-b11f-40d7-b595-a4183b8138c5");
            //var uri = new Uri(PdfHtmlTemplate.Replace("ViewMyWeeklyPlansDetails", "ViewMyWeeklyPlansDetailsPrint"));
            //var urlToPdf = new HtmlToPdf();
            //var pdf = urlToPdf.RenderUrlAsPdf(uri);
            //var filename = "file" + Guid.NewGuid().ToString() + ".pdf";
            //pdf.SaveAs(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/files/" + filename));
            SetViewBag();
            return Json(new { Status = "OK", Filename = "" });
            //return Json(new { Status = "OK", Filename = filename });
        }

        public IActionResult BuildIronPDFNurseryURL(string PdfHtmlTemplate)
        {
            //var uri = new Uri("https://localhost:44304/BackOffice/Plan/ViewMyPlanDetailsPrint/g0b74728-b11f-40d7-b595-a4183b8138c5");
            //var uri = new Uri(PdfHtmlTemplate.Replace("ViewMyWeeklyPlansDetails", "ViewMyWeeklyPlansDetailsPrint"));
            //var urlToPdf = new HtmlToPdf();
            //var pdf = urlToPdf.RenderUrlAsPdf(uri);
            //var filename = "file" + Guid.NewGuid().ToString() + ".pdf";
            //pdf.SaveAs(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/files/" + filename));
            //SetViewBag();
            //return Json(new { Status = "OK", Filename = filename });
            return Json(new { Status = "OK", Filename = "" });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            SetViewBag();
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
      
        public class Days
        {
            public int Id { get; set; }

            public string Name { get; set; }
        }
    }
}
