using Microsoft.AspNetCore.Mvc;

namespace DemoMvc.Controllers
{

    public class DemoController : Controller
    {
        // Hiển thị form

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        // Nhận dữ liệu từ form
        [HttpPost]
        public IActionResult Index(string fullName, string maSoSinhVien )
        {
            ViewBag.Message = "Xin chào " + fullName + " Mã sinh viên: " + maSoSinhVien;
            return View();
        }
    }


}