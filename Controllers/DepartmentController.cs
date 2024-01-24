using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OnlineCommercialAutomation.Models.Classes;

namespace OnlineCommercialAutomation.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly Context _context;

        public DepartmentController(Context context){

            _context = context;
        }

        public IActionResult Index()
        {
            var values = _context.Departments.Where(x => x.isActive == true).Include(x => x.Employees).ToList();
            var depListProvider = DepartmentProvider.Instance;
            var dep = depListProvider.GetDepList();
            return View(dep);
        }

        [HttpGet]
        public IActionResult AddDepartment()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddDepartment(Department newDep)
        {
            _context.Departments.Add(newDep);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult RemoveDepartment(int id)
        {
            var dep = _context.Departments.Find(id);
            dep.isActive = false;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult GetDepartment(int id)
        {
            var dep = _context.Departments.Find(id);
            return View("GetDepartment", dep);
        }

        public IActionResult EditDepartment(Department d)
        {
            var dep = _context.Departments.Find(d.DepartmentId);
            dep.DepartmentName = d.DepartmentName;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult DepartmentDetail(int id)
        {
            var emp = _context.Employees.Where(x => x.DepartmentId == id).ToList();
            var dpt = _context.Departments.Where(x => x.DepartmentId == id).Select(y => y.DepartmentName).FirstOrDefault();
            ViewBag.d = dpt;
            return View(emp);
        }

        public IActionResult DepEmpSales(int id)
        {
            var sales = _context.SalesMoves.Where(x => x.EmployeeId == id)
            .Include(x => x.Customer)
            .Include(x => x.Employee)
            .Include(x => x.Product)
            .ToList();
            var emp = _context.Employees.Where(x => x.EmployeeId == id).Select(y => y.EmployeeName + " " + y.EmployeeLastName).FirstOrDefault();
            ViewBag.eName = emp;
            return View(sales);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}