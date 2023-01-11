using Microsoft.AspNetCore.Mvc;

namespace Ajax_Test_Application.Controllers
{
    public class JQueryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult JQuery()
        {
            return View();
        }

        public IActionResult PartialView()
        {
            ViewBag.AAA = "Heleo PartialVIew!";
            return PartialView();
        }
    }
}
