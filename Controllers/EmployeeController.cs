using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace OnlineCommercialAutomation.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly Context _context;

        public EmployeeController(Context context){

            _context = context;
        }

        public IActionResult Index()
        {
            var emp = _context.Employees
            .Include(x => x.Department)
            .ToList();
            return View(emp);
        }

        [HttpGet]
        public IActionResult AddEmployee()
        {
            List<SelectListItem> values = (from x in _context.Departments.ToList()
            select new SelectListItem
            {
                Text = x.DepartmentName,
                Value = x.DepartmentId.ToString()
            }).ToList();
            
            ViewBag.value = values;
            return View();
        }

        [HttpPost]
        public IActionResult AddEmployee(Employee e)
        {
            _context.Employees.Add(e);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult GetEmployee(int id)
        {
            List<SelectListItem> values = (from x in _context.Departments.ToList()
            select new SelectListItem
            {
                Text = x.DepartmentName,
                Value = x.DepartmentId.ToString()
            }).ToList();

            ViewBag.value = values;

            var emp = _context.Employees.Find(id);
            return View("GetEmployee", emp);
        }

        public IActionResult EditEmployee(Employee e)
        {
            var emp = _context.Employees.Find(e.EmployeeId);
            emp.EmployeeName = e.EmployeeName;
            emp.EmployeeLastName = e.EmployeeLastName;
            emp.EmployeeImage = e.EmployeeImage;
            emp.DepartmentId = e.DepartmentId;

            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}