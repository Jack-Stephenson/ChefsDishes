using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ChefsDishes.Models;
using Microsoft.EntityFrameworkCore;

namespace ChefsDishes.Controllers
{
    public class HomeController : Controller
    {
        private MyContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, MyContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            ViewBag.AllChefs = _context.Chefs.Include(s=>s.Dishes).ToList();
            return View();
        }
        [HttpGet("MakeChef")]
        public IActionResult MakeChef()
        {
            return View();
        }
        [HttpPost("NewChef")]
        public IActionResult NewChef(Chef newChef)
        {
            if (ModelState.IsValid)
            {
                int current = int.Parse(DateTime.Now.ToString("yyyyMMdd"));
                int dob = int.Parse(newChef.DateOfBirth.ToString("yyyyMMdd"));
                if(dob>current)
                {
                    ModelState.AddModelError("DateOfBirth", "Chef cannot be born in the future");
                    return View("MakeChef");
                }
                _context.Chefs.Add(newChef);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AllChefs = _context.Chefs.Include(s=>s.Dishes).ToList();
            return View("MakeChef");
        }
        [HttpGet("Dishes")]
        public IActionResult Dishes()
        {
            ViewBag.AllDishes = _context.Dishes.Include(s=>s.Chef).ToList();
            return View();
        }
        [HttpGet("MakeDish")]
        public IActionResult MakeDish()
        {
            ViewBag.AllChefs = _context.Chefs.ToList();
            return View();
        }
        [HttpPost("NewDish")]
        public IActionResult NewDish(Dish newDish)
        {
            if (ModelState.IsValid)
            {
                _context.Dishes.Add(newDish);
                _context.SaveChanges();
                return RedirectToAction("Dishes");
            }
            ViewBag.AllChefs = _context.Chefs.ToList();
            return View("MakeDish");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
