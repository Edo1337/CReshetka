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
        public IActionResult SortAlgorithms(bool resultTest, string resultsMessage, int correctAnswers, int totalQuestions)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var nameTest = "Алгоритмы сортировки";
            var isComplited = _context.TestResults.Any(tr => tr.UserId == userId && tr.NameTest == nameTest);

            // Проверка, выполнил ли человек тест верно, если так, то
            // только в этом случае обращаемся к БД и смотрим проходил ли пользователь тест ранее
            if (resultTest && !isComplited)
            {
                // Пользователь не проходил тест ранее, записываем результаты
                var testResult = new TestResult
                {
                    Timestamp = DateTime.Now,
                    UserId = userId,
                    NameTest = nameTest
                };

                _context.TestResults.Add(testResult);
                _context.SaveChanges();
            }

            ViewBag.ResultsMessage = resultsMessage;
            ViewBag.CorrectAnswers = correctAnswers;
            ViewBag.TotalQuestions = totalQuestions;

            return View("ResultsView");
        }

        [HttpGet]
        public IActionResult BubbleSort()
        {
            return View();
        }
        [HttpPost]
        public IActionResult BubbleSort(bool resultTest, string resultsMessage, int correctAnswers, int totalQuestions)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var nameTest = "Сортировка пузырьком (Bubble Sort)";
            var isComplited = _context.TestResults.Any(tr => tr.UserId == userId && tr.NameTest == nameTest);

            // Проверка, выполнил ли человек тест верно, если так, то
            // только в этом случае обращаемся к БД и смотрим проходил ли пользователь тест ранее
            if (resultTest && !isComplited)
            {
                // Пользователь не проходил тест ранее, записываем результаты
                var testResult = new TestResult
                {
                    Timestamp = DateTime.Now,
                    UserId = userId,
                    NameTest = nameTest
                };

                _context.TestResults.Add(testResult);
                _context.SaveChanges();
            }

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
