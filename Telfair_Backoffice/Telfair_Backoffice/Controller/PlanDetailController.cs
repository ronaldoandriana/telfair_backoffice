using Microsoft.AspNetCore.Mvc;

namespace Telfair_Backend.Controllers
{
    public class PlanDetailController : BaseController
    {
        public IActionResult PlanDetail()
        {
            SetViewBag();
            return View();
        }

      

    }
}
