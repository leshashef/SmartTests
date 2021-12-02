using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SmartTests.Models;
using SmartTests.Models.Context;

namespace SmartTests.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private AppDbContext dbContext;
   
        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            dbContext = context;
        }

        public IActionResult Index()
        {
            dbContext.Users.Add(new UserModel { Login = "leshashef", Name = "leshashef" });
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Contact(DateTime index)
        {
            return Json(index);
        }
    }
}
