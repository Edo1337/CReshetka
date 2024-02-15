using CReshetka.Data;
using CReshetka.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Security.Claims;

namespace CReshetka.Controllers
{
    public class TestingController : Controller
    {
        private readonly ILogger<TestingController> _logger;
        private readonly ApplicationDbContext _context;
        public TestingController(ILogger<TestingController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SortAlgorithms()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SortAlgorithms(bool resultTest, int correctAnswers, string resultsMessage, int totalQuestions)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var isComplited = _context.TestResults.Any(tr => tr.UserId == userId && tr.NameTest == "Алгоритмы сортировки");

            // Проверка, выполнил ли человек тест верно, если так, то
            // только в этом случае обращаемся к БД и смотрим проходил ли пользователь тест ранее
            if (resultTest && !isComplited)
            {
                // Пользователь не проходил тест ранее, записываем результаты
                var testResult = new TestResult
                {
                    Timestamp = DateTime.Now,
                    UserId = userId,
                    NameTest = "Алгоритмы сортировки"
                };

                _context.TestResults.Add(testResult);
                _context.SaveChanges();

            }

            //var totalQuestions = 20;

            ViewBag.ResultsMessage = resultsMessage;
            ViewBag.CorrectAnswers = correctAnswers;
            ViewBag.TotalQuestions = totalQuestions;

            return View("ResultsView");
        }

        public IActionResult ResultsView()
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
