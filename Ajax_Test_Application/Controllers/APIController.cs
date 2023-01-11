using Ajax_Test_Application.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Xml.Linq;

namespace Ajax_Test_Application.Controllers
{
    public class APIController : Controller
    {
        DemoContext _db ;
        public APIController(DemoContext db)
        {         
           _db= db;
        }

         


        public IActionResult Index(string name,string age)
        {
            if (string.IsNullOrEmpty(name))
            {
                name = "Ajax";
            }

            return Content($"<h2>你好,{name},{age}歲</h2>","text/plan",Encoding.UTF8);
        }

        public IActionResult City()
        {
            var cities = _db.Addresses.Select(a => new { a.City}).Distinct().OrderBy(a => a.City);
            return Json(cities);
        }

        public IActionResult Site(string city)
        {
            var Sites = _db.Addresses.Where(c=> c.City == city).Select(a => new { a.SiteId }).Distinct().OrderBy(a => a.SiteId);
            return Json(Sites);
        }

        public IActionResult Road(string site)
        {
            var Roads = _db.Addresses.Where(c=>c.SiteId==site).Select(a => new { a.Road }).Distinct().OrderBy(a => a.Road);
            return Json(Roads);
        }
    }

   

}
