using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission08_group1_9.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission08_group1_9.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        private TaskContext _privateTaskContext { get; set; }
        public HomeController(TaskContext MeganFox)
        {
            _privateTaskContext = MeganFox;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddTask()
        {
            ViewBag.Task = _privateTaskContext.Tasks.ToList();

            return View(new Mission08_group1_9.Models.Task());
        }

        [HttpPost]
        public IActionResult AddTask(Mission08_group1_9.Models.Task task)
        {
            if (ModelState.IsValid)
            {
                _privateTaskContext.Add(task);
                _privateTaskContext.SaveChanges();
                return View(task);
            }
            else
            {
                ViewBag.Task = _privateTaskContext.Tasks.ToList();
                return View(task);
            }

        }

        [HttpGet]
        public IActionResult Quadrants()
        {
            var prospectives = _privateTaskContext.Tasks
                .Include(x => x.Category)
                .ToList();

            return View(prospectives);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Task = _privateTaskContext.Categories.ToList();
            var submission = _privateTaskContext.Tasks.Single(x => x.CategoryId == id);

            return View("AddTask", submission);
        }

        [HttpPost]
        public IActionResult Edit(Mission08_group1_9.Models.Task keiraKnightley)
        {
            _privateTaskContext.Update(keiraKnightley);
            _privateTaskContext.SaveChanges();

            return RedirectToAction("Quadrants");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var submission = _privateTaskContext.Tasks.Single(x => x.CategoryId == id);
            return View(submission);
        }

        [HttpPost]
        public IActionResult Delete(Mission08_group1_9.Models.Task task)
        {
            _privateTaskContext.Tasks.Remove(task);
            _privateTaskContext.SaveChanges();

            return RedirectToAction("Quadrants");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

