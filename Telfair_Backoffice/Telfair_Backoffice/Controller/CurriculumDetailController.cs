using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Telfair_Backend.Classes.Models;
using Telfair_Backend.Classes.Services;

namespace Telfair_Backend.Controllers
{
    public class CurriculumDetailController : BaseController
    {
        public IActionResult CurriculumDetail()
        {
            PlanService ser = new PlanService();
            ViewBag.CurriculumModel = new SelectList(ser.GetCurriculumModels(), "Id", "Name"); 
            ViewBag.LessonModel = new SelectList(ser.GetLessonModels(), "Id", "Name");
            SetViewBag();
            return View();
        }        

        public IActionResult SaveCurriculumDetail(CurriculumDetailModel curriculumDetail)
        {
            PlanService ser = new PlanService();            
            ser.SaveCurriculumDetail(curriculumDetail);
            SetViewBag();
            return RedirectToAction("CurriculumDetail");
        }

        public ActionResult ViewCurriculumDetail()
        {
            PlanService ser = new PlanService();
            var curriculumDetails = ser.ViewCurriculumDetail();
            ViewData["CurriculumDetails"] = curriculumDetails;
            SetViewBag();
            return View(curriculumDetails);
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            PlanService ser = new PlanService();
            ViewBag.CurriculumModel = new SelectList(ser.GetCurriculumModels(), "Id", "Name");
            ViewBag.LessonModel = new SelectList(ser.GetLessonModels(), "Id", "Name");
            CurriculumDetailModel model = ser.GetCurriculumDetailById(id);
            SetViewBag();
            return View("CurriculumDetail", model);
        }

        public IActionResult Delete(string id)
        {
            PlanService ser = new PlanService();
            int result = ser.DeleteCurriculumDetail(id);
            SetViewBag();
            return RedirectToAction("ViewCurriculumDetail");
        }

    }
}
