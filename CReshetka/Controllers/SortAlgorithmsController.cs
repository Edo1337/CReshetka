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

        [HttpGet]
        public IActionResult CocktailSort()
        {
            return View();
        }

        [HttpGet]
        public IActionResult InsertionSort()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ShellSort()
        {
            return View();
        }
        
        [HttpGet]
        public IActionResult TreeSort()
        {
            return View();
        }
        
        [HttpGet]
        public IActionResult HeapSort()
        {
            return View();
        }
        
        [HttpGet]
        public IActionResult SelectionSort()
        {
            return View();
        }
        
        [HttpGet]
        public IActionResult GnomeSort()
        {
            return View();
        }
        
        [HttpGet]
        public IActionResult RadixSort()
        {
            return View();
        } 
        
        [HttpGet]
        public IActionResult MergeSort()
        {
            return View();
        }


    }
}
