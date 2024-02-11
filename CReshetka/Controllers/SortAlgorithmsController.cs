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

        public IActionResult BubbleSort()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // Получение UserId текущего пользователя

            // Проверка, проходил ли пользователь тест ранее
            var hasCompletedTest = _context.TestResults.Any(tr => tr.UserId == userId && tr.NameTest == "ваше_название_теста");

            if (!hasCompletedTest)
            {
                // Пользователь не проходил тест ранее, записываем результаты
                var testResult = new TestResult
                {
                    Timestamp = DateTime.Now,
                    UserId = userId,
                    NameTest = "ваше_название_теста", // Замените на реальное название вашего теста
                    IsCompleted = true
                };

                _context.TestResults.Add(testResult);
                _context.SaveChanges();
            }

            //    //// Подготавливаем данные для передачи в представление
            //    //var correctAnswers = 2;// ваша логика для подсчета правильных ответов
            //    //var totalQuestions = 2;// ваша логика для подсчета общего числа вопросов

            //    //ViewBag.ResultsMessage = "Ваши результаты сохранены.";
            //    //ViewBag.CorrectAnswers = correctAnswers;
            //    //ViewBag.TotalQuestions = totalQuestions;

            return View();
        }

        public IActionResult ResultsView()
            {
                return View();
            }
            //public IActionResult BubbleSort()
            //{
            //    return View();
            //}
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
