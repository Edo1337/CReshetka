using Microsoft.AspNetCore.Mvc;

namespace CReshetka.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult BubbleSort()
        {
            return View();
        }

    }
}
