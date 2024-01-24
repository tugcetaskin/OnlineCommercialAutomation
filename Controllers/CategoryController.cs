using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineCommercialAutomation.Models;

namespace OnlineCommercialAutomation.Controllers
{
    public class CategoryController : Controller
    {
        private readonly Context _context;

        public CategoryController(Context context){

            _context = context;
        }
        public IActionResult Index()
        {
            var values = _context.Categories.ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCategory(Category c)
        {
            _context.Categories.Add(c);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult RemoveCategory(int id)
        {
            var rCategory = _context.Categories.Find(id);
            _context.Categories.Remove(rCategory);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult GetCategory(int id)
        {
            var category = _context.Categories.Find(id);
            return View("GetCategory", category);
        }

        public IActionResult EditCategory(Category c)
        {
            var category = _context.Categories.Find(c.CategoryId);
            category.CategoryName = c.CategoryName;
            _context.SaveChanges();
            return RedirectToAction("Index");

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}