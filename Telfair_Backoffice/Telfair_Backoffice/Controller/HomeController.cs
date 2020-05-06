using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using SAIM.Core.BusinessObjects.Model;
using Telfair_Backend.Classes.Services;
using Telfair_Backend.Classes.Models;

namespace Telfair_Backend.Controllers
{
    public class HomeController : BaseController
    {

        //private readonly SignInManager<IdentityUser> signInManager;
        //public HomeController(SignInManager<IdentityUser> signInManager)
        //{
        //    this.signInManager = signInManager;
        //}

        public IActionResult Index()
        {
            //if (SessionIsNull()) return Redirect("/Home/Login?mustLogin=true&next=/Home/Index");
            SetViewBag();
            return View("Login");
        }

        public IActionResult Privacy()
        {
            SetViewBag();
            if (SessionIsNull()) return Redirect("/Home/Login?mustLogin=true&next=/Home/Privacy");
            return View();
        }

        public IActionResult Plan()
        {
            if (SessionIsNull()) return Redirect("/Home/Login?mustLogin=true&next=/Home/Plan");
            SetViewBag();
            return View();
        }

        public IActionResult Login(string mustLogIn, string next)
        {
            SetViewBag();
            if (SessionIsNull())
            {
                if (mustLogIn != null && mustLogIn.Equals("true")) ModelState.AddModelError("", "You must login first");
                if (!string.IsNullOrEmpty(next)) ViewBag.next = next; 
                return View();
            }
            else
            {
                return RedirectToAction("HomePage", "Home");
            }
        }

        [HttpPost]
        public IActionResult Login(UserModel model)
        {
           // HttpContext.Session.SetString("LoginName", model.UserName);
            if(model.UserName == null || model.Password == null)
            {
                ModelState.AddModelError("", "All fields are required");
                return View(model);
            }
            var user = new PlanService().GetUser(model.UserName, model.Password);

            

            if (user != null && !string.IsNullOrEmpty(user.Id))
            {
                HttpContext.Session.SetString("LoginName", user.UserName);
                HttpContext.Session.SetString("FirstName", user.Person.FirstName);
                HttpContext.Session.SetString("LastName", user.Person.LastName);
                HttpContext.Session.SetString("RoleName", user.Role.Name);
                HttpContext.Session.SetString("RoleId", user.Role.Id);
                HttpContext.Session.SetString("EmployeeId", user.Person.EmployeeId);
                if (string.IsNullOrEmpty(model.Next)) return RedirectToAction("HomePage", "Home");
                else return Redirect(model.Next);
            }
            else
            {
                if (!string.IsNullOrEmpty(model.Next)) ViewBag.next = model.Next;
                ModelState.AddModelError("", "Invalid username or password");
                return View(model);
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            SetViewBag();
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        #region signin

        //[HttpPost]
        //public async Task<IActionResult> Logout()
        //{
        //    await signInManager.SignOutAsync();
        //    return RedirectToAction("index", "home");
        //}

        //[HttpGet]
        //public IActionResult Login()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public async Task<IActionResult> Login(LoginModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var result = await signInManager.PasswordSignInAsync(
        //            model.Email, model.Password, model.RememberMe, false);

        //        if (result.Succeeded)
        //        {
        //            return RedirectToAction("index", "home");
        //        }

        //        ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
        //    }

        //    return View(model);
        //}

        #endregion

        public IActionResult HomePage()
        {
            if (SessionIsNull())
            {
                ModelState.AddModelError("", "You must login first");
                return View("Login");
            }
            SetViewBag();
            return View();
        }
    }
}
