using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Telfair_Backend.Classes.Models;
using Telfair_Backend.Classes.Services;

namespace Telfair_Backend.Controllers
{
    public class BlogController : BaseController
    {
        public IActionResult Blog (string error)
        {
            try
            {
                if (SessionIsNull()) return Redirect("/Home/Login?mustLogin=true&next=/Blog/Blog");
                SetViewBag();
                if (!string.IsNullOrEmpty(error) && error.Equals("true")) SetSavingError();
                ViewBag.title = "Add news";
            }
            catch (Exception)
            {
                SetDefaultError();
            }
            return View();
        }

        public IActionResult SaveBlog(BlogModel blog)
        {
            try
            {
                PlanService ser = new PlanService();
                blog.ModifiedBy = HttpContext.Session.GetString("LoginName");
                int result = ser.SaveBlog(blog);
                SetViewBag();
                if(result == 1) return Redirect("/Blog/ViewBlog?success=true");
                else return Redirect("/Blog/Blog?error=true");
            }
            catch (Exception)
            {
                return Redirect("/Blog/Blog?error=true");
            }
        }

        public ActionResult ViewBlog(string page, string success, string delete_success, string delete_error)
        {
            var blogs = new List<BlogModel>();
            try
            {
                if (SessionIsNull()) return Redirect("/Home/Login?mustLogin=true&next=/Blog/ViewBlog?page="+page);
                PlanService ser = new PlanService();
                int _page = 1;
                bool isParsed = int.TryParse(page, out _page);
                if (!isParsed || _page <= 0) _page = 1;
                blogs = ser.ViewBlog(10, _page);
                int nombre = ser.CountBlog();
                ViewBag.pagination = new PageUtility().MakePagination(10, nombre, _page, "/Blog/ViewBlog?page=");
                SetViewBag();
                if (!string.IsNullOrEmpty(success) && success.Equals("true")) ViewBag.success = "Saving with success!";
                if (!string.IsNullOrEmpty(delete_success) && delete_success.Equals("true")) ViewBag.success = "Deleting with success!";
                if (!string.IsNullOrEmpty(delete_error) && delete_error.Equals("true")) ViewBag.error = "An error has occured while deleting!";
            }
            catch (Exception)
            {
                ViewBag.error = "An error has occured!";
            }
            return View(blogs);
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {

            try
            {
                if (SessionIsNull()) return Redirect("/Home/Login?mustLogin=true&next=/Blog/Edit?id="+id);
                PlanService ser = new PlanService();
                BlogModel model = ser.ViewBlogById(id);
                SetViewBag();
                ViewBag.title = "Edit news";
                return View("Blog", model);
            }
            catch (Exception)
            {
                return View("Blog");
            }

        }

        public IActionResult Delete(string id)
        {

            try
            {
                if (SessionIsNull()) return Redirect("/Home/Login?mustLogin=true&next=/Blog/Delete?id="+id);
                PlanService ser = new PlanService();
                int result = ser.DeleteBlog(id);
                SetViewBag();
                if(result == 1) return Redirect("/Blog/ViewBlog?delete_success=true");
                else return Redirect("/Blog/ViewBlog?delete_success=true");
            }
            catch (Exception)
            {
                return Redirect("/Blog/ViewBlog?delete_error=true");
            }

        }

    

    
    }
}
