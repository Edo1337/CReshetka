using CReshetka.Data;
using CReshetka.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Security.Claims;

namespace CReshetka.Controllers
{
    [Authorize]
    public class TestingController : Controller
    {
        private readonly ApplicationDbContext _context;
        public TestingController(ILogger<TestingController> logger, ApplicationDbContext context)
        {
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
            return ProcessTestResults(resultTest, resultsMessage, correctAnswers, totalQuestions, "Алгоритмы сортировки");
        }

        [HttpGet]
        public IActionResult BubbleSort()
        {
            return View();
        }
        [HttpPost]
        public IActionResult BubbleSort(bool resultTest, string resultsMessage, int correctAnswers, int totalQuestions)
        {
            return ProcessTestResults(resultTest, resultsMessage, correctAnswers, totalQuestions, "Сортировка пузырьком (Bubble Sort)");
        }
        
        [HttpGet]
        public IActionResult CocktailSort()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CocktailSort(bool resultTest, string resultsMessage, int correctAnswers, int totalQuestions)
        {
            return ProcessTestResults(resultTest, resultsMessage, correctAnswers, totalQuestions, "Шейкерная сортировка (Cocktail Sort)");
        }

        [HttpGet]
        public IActionResult InsertionSort()
        {
            return View();
        }
        [HttpPost]
        public IActionResult InsertionSort(bool resultTest, string resultsMessage, int correctAnswers, int totalQuestions)
        {
            return ProcessTestResults(resultTest, resultsMessage, correctAnswers, totalQuestions, "Сортировка вставками (Insertion Sort)");
        }
        
        [HttpGet]
        public IActionResult ShellSort()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ShellSort(bool resultTest, string resultsMessage, int correctAnswers, int totalQuestions)
        {
            return ProcessTestResults(resultTest, resultsMessage, correctAnswers, totalQuestions, "Сортировка Шелла (Shell Sort)");
        }
        
        [HttpGet]
        public IActionResult TreeSort()
        {
            return View();
        }
        [HttpPost]
        public IActionResult TreeSort(bool resultTest, string resultsMessage, int correctAnswers, int totalQuestions)
        {
            return ProcessTestResults(resultTest, resultsMessage, correctAnswers, totalQuestions, "Сортировка деревом (Tree Sort)");
        }
        
        [HttpGet]
        public IActionResult HeapSort()
        {
            return View();
        }
        [HttpPost]
        public IActionResult HeapSort(bool resultTest, string resultsMessage, int correctAnswers, int totalQuestions)
        {
            return ProcessTestResults(resultTest, resultsMessage, correctAnswers, totalQuestions, "Сортировка кучей (Heap Sort)");
        }
        
        [HttpGet]
        public IActionResult SelectionSort()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SelectionSort(bool resultTest, string resultsMessage, int correctAnswers, int totalQuestions)
        {
            return ProcessTestResults(resultTest, resultsMessage, correctAnswers, totalQuestions, "Сортировка выбором (Selection ort)");
        }
        
        [HttpGet]
        public IActionResult GnomeSort()
        {
            return View();
        }
        [HttpPost]
        public IActionResult GnomeSort(bool resultTest, string resultsMessage, int correctAnswers, int totalQuestions)
        {
            return ProcessTestResults(resultTest, resultsMessage, correctAnswers, totalQuestions, "Гномья сортировка (Gnome Sort)");
        }
        
        [HttpGet]
        public IActionResult RadixSort()
        {
            return View();
        }
        [HttpPost]
        public IActionResult RadixSort(bool resultTest, string resultsMessage, int correctAnswers, int totalQuestions)
        {
            return ProcessTestResults(resultTest, resultsMessage, correctAnswers, totalQuestions, "Поразрядная сортировка (Radix Sort)");
        }
        
        [HttpGet]
        public IActionResult MergeSort()
        {
            return View();
        }
        [HttpPost]
        public IActionResult MergeSort(bool resultTest, string resultsMessage, int correctAnswers, int totalQuestions)
        {
            return ProcessTestResults(resultTest, resultsMessage, correctAnswers, totalQuestions, "Сортировка слиянием (Merge Sort)");
        }
        
        [HttpGet]
        public IActionResult QuickSort()
        {
            return View();
        }
        [HttpPost]
        public IActionResult QuickSort(bool resultTest, string resultsMessage, int correctAnswers, int totalQuestions)
        {
            return ProcessTestResults(resultTest, resultsMessage, correctAnswers, totalQuestions, "Быстрая сортировка (Quick Sort)");
        }

        [HttpPost]
        public IActionResult ProcessTestResults(bool resultTest, string resultsMessage, int correctAnswers, int totalQuestions, string testName)
        {
            //var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            //var isComplited = _context.TestResults.Any(tr => tr.UserId == userId && tr.NameTest == testName);

            // Проверка, выполнил ли человек тест верно, если так, то только в этом случае
            // обращаемся к БД и смотрим проходил ли пользователь тест ранее
            if (resultTest && !_context.TestResults.Any(tr => tr.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier) && tr.NameTest == testName))
            {
                // Пользователь не проходил тест ранее, записываем результаты
                var testResult = new TestResult
                {
                    Timestamp = DateTime.Now,
                    UserId = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    NameTest = testName
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
