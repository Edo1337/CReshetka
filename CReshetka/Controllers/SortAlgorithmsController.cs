using CReshetka.Constants;
using CReshetka.Data;
using CReshetka.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CReshetka.Controllers
{
    public class SortAlgorithmsController : Controller
    {
        private readonly ApplicationDbContext _context;
        public SortAlgorithmsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult BubbleSort()
        {
            return View();
        }

        [HttpPost]
        public IActionResult BubbleSort(bool resultTest)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var hasCompletedTest = _context.TestResults.Any(tr => tr.UserId == userId && tr.NameTest == "Сортировка пузырьком");

            // Проверка, проходил ли пользователь тест ранее и выполнил ли он его верно в этот раз
            if (!hasCompletedTest && resultTest)
            {
                // Пользователь не проходил тест ранее, записываем результаты
                var testResult = new TestResult
                {
                    Timestamp = DateTime.Now,
                    UserId = userId,
                    NameTest = "Сортировка пузырьком"
                };

                _context.TestResults.Add(testResult);
                _context.SaveChanges();

            }

            // Подготавливаем данные для передачи в представление
            var correctAnswers = 2;
            var totalQuestions = 2;

            ViewBag.ResultsMessage = "Ваши результаты сохранены.";
            ViewBag.CorrectAnswers = correctAnswers;
            ViewBag.TotalQuestions = totalQuestions;

            return View("ResultsView");
        }

        public IActionResult ResultsView()
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
