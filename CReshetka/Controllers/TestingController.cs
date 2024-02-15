using Microsoft.AspNetCore.Mvc;

namespace CReshetka.Controllers
{
    public class TestingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
