using Microsoft.AspNetCore.Mvc;

namespace DemoMvc.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
