﻿using System;
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
            var menus = _dbContext.Menus.ToList();
            return View(menus);
        }
        public IActionResult Edit(Guid id)
        {
            var menu = _dbContext.Menus.Find(id);
            if(menu == null)
                return NotFound();
            var editbaleMenu = new EditableMenu(menu.Id,menu.Name,menu.IsPublic,menu.CssClass,menu.Description);
            return View(editbaleMenu);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(EditableMenu model)
        {
            if(ModelState.IsValid)
            {
                UpdateMenu(model);  
                ClearAllMenuItems(model.Id);

            }
            return View(model);
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
        private void UpdateMenu(EditableMenu menu)
        {
            var targetMenu = _dbContext.Menus.Find(menu.Id);
            targetMenu.CssClass = menu.CssClass;
            targetMenu.Description = menu.Description;
            targetMenu.IsPublic = menu.IsPublic;
            targetMenu.Name = targetMenu.Name;
            _dbContext.Update<Menu>(targetMenu);
            _dbContext.SaveChanges();
        }
        private void ClearAllMenuItems(Guid menuId)
        {
            var menuItems = _dbContext.MenuItems.Where(i => i.MenuId == menuId).ToList();
            if(menuItems != null && menuItems.Count > 0)
            {
                foreach (var item in menuItems)
                {
                    _dbContext.MenuItems.Remove(item);
                }
            }
            _dbContext.SaveChanges();
        }
        private void AddMenuItems(List<string> texts,List<string> Links,List<string> cssClasses,
            List<bool> openInNewTab,List<bool> linkIsEditable,List<string> parents)
        {
            
        }
    }
}
