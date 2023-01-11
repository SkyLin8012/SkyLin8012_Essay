using Ajax_Test_Application.Models;
using Ajax_Test_Application.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Xml.Linq;

namespace Ajax_Test_Application.Controllers
{
    public class HomeWorkController : Controller
    {
        private readonly IWebHostEnvironment _host;
        private DemoContext _db;

        public HomeWorkController(IWebHostEnvironment host, DemoContext db)
        {
            _host = host;
            _db = db;
        }

        public IActionResult asyncFetchCity() {
            return View();
        
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult register()
        {
            return View();             
        }

        [HttpPost]
        public IActionResult JSPost(Member me,IFormFile photo)
        {
        //System.Threading.Thread.Sleep(5000);

        if (string.IsNullOrEmpty(me.Name))
        {
            me.Name = "Ajax";
        }
            string filePath = Path.Combine(_host.WebRootPath, "imgs", photo.FileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                photo.CopyTo(fileStream);
            }
            //將圖轉成二進位
            byte[]? imgByte = null;
            using (var mstream = new MemoryStream())
            { 
                photo.CopyTo(mstream);
                imgByte = mstream.ToArray();
            }   
            me.FileName= photo.FileName;
            me.FileData = imgByte;
            //將會員資料寫入資料庫
            _db.Members.Add(me);
            _db.SaveChanges();

            //輸出純文字HTML 標籤碼
            //string Htmlstr = $"<li class='list-group-item'>姓名:{me.Name}</li><li class='list-group-item'>Email:{me.Email}</li><li class='list-group-item'>年齡:{me.Age}</li><li class='list-group-item'>檔名:{me.FileName}</li>";
            ////return Content($"Hello, {me.Name}, You are {me.Age} years old,Email: {me.Email} ,檔案名稱{photo.FileName} 存放{filePath}。", "text/plain", Encoding.UTF8);
            //return Content(Htmlstr, "text/plain", Encoding.UTF8);

            //輸出JSON
            return Json(me);

        }




        public IActionResult SaveMember(string name,string age, string email )
        {
           DemoContext db= new DemoContext();

            var data = db.Members.Where(m => m.Name.Contains(name)).ToList();
             Member me = new Member();
            if (data.Count ==0)
            {
                me.MemberId = db.Members.Count() + 1;    
                me.Name = name;
                me.Age = Convert.ToInt32(age);
                me.Email = email;               
                db.Members.Add(me);
                db.SaveChanges();
                return Json(me);
            }
            else
            {
                return Json(me);
            }
          

        }
    }
}
