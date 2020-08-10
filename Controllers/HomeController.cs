using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MenuTest.Dal;
using MenuTest.Models;
using MenuTest.ViewModels;
namespace MenuTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MenuDbContext _dbContext;
        public HomeController(ILogger<HomeController> logger,MenuDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Manage()
        {
            var editbaleMenu = new EditableMenu();
            editbaleMenu.Id = 12;
            return View(editbaleMenu);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Manage(EditableMenu model)
        {
            if(ModelState.IsValid)
            {
                
            }
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
    }
}
