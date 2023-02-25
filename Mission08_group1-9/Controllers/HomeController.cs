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
            ViewBag.Categories = _privateTaskContext.Categories.ToList();

            return View(new Mission08_group1_9.Models.Tasko());
        }

        [HttpPost]
        public IActionResult AddTask(Mission08_group1_9.Models.Tasko task)
        {
            if (ModelState.IsValid)
            {
                _privateTaskContext.Add(task);
                _privateTaskContext.SaveChanges();
                return View(task);
            }
            else
            {
                ViewBag.Categories = _privateTaskContext.Categories.ToList();
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
        public IActionResult Edit(int taskid)
        {
            ViewBag.Categories = _privateTaskContext.Categories.ToList();
            var submission = _privateTaskContext.Tasks.Single(x => x.TaskId == taskid);

            return View("AddTask", submission);
        }

        [HttpPost]
        public IActionResult Edit(Mission08_group1_9.Models.Tasko keiraKnightley)
        {
            _privateTaskContext.Update(keiraKnightley);
            _privateTaskContext.SaveChanges();

            return RedirectToAction("Quadrants");
        }

        [HttpGet]
        public IActionResult Delete(int taskid)
        {
            var submission = _privateTaskContext.Tasks.Single(x => x.TaskId == taskid);
            return View(submission);
        }

        [HttpPost]
        public IActionResult Delete(Mission08_group1_9.Models.Tasko task)
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

