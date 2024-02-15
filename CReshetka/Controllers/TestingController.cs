using CReshetka.Data;
using CReshetka.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CReshetka.Controllers
{
    public class TestingController : Controller
    {
        private readonly ILogger<TestingController> _logger;
        public TestingController(ILogger<TestingController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
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
