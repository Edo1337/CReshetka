using Microsoft.AspNetCore.Mvc;

namespace CReshetka.Controllers
{
    public class SortAlgorithmsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult BubbleSort()
        {
            return View();
        }
        public IActionResult CocktailSort()
        {
            return View();
        }
        public IActionResult InsertionSort()
        {
            return View();
        }
    }
}
