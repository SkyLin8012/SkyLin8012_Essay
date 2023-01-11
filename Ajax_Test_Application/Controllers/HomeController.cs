using Ajax_Test_Application.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Ajax_Test_Application.Controllers
{
    public class HomeController : Controller
    {
        private readonly DemoContext _Demotxt;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, DemoContext demotxt)
        {
            _logger = logger;
            _Demotxt = demotxt;
        }
        public IActionResult Partial()
        {
            ViewBag.Data = "Hello PartailVIew";
            return PartialView(_Demotxt.Members); //要回傳EF的資料表
        }

        public IActionResult Travel() {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult list()
        {
            var members = _Demotxt.Members.Where(p => p.Age > 1);
            return View(members);
        }

        public IActionResult City()
        {
            return View();
        }

        public IActionResult fetchtest()
        {
            return View();
        }
        public IActionResult Ajax()
        {
            return View();
        }

        public IActionResult PostAjax()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}