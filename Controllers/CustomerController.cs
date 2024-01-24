using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;

namespace OnlineCommercialAutomation.Controllers
{
    public class CustomerController : Controller
    {
        private readonly Context _context;

        public CustomerController(Context context){

            _context = context;
        }
        
        public IActionResult Index()
        {
            var customers = _context.Customers.Where(x => x.IsActive == true).ToList();
            return View(customers);
        }

        [HttpGet]
        public IActionResult AddCustomer()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCustomer(Customer c)
        {
            c.IsActive = true;
            _context.Customers.Add(c);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult RemoveCustomer(int id)
        {
            var cust = _context.Customers.Find(id);
            cust.IsActive=false;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult GetCustomer(int id)
        {
            var cust = _context.Customers.Find(id);
            return View("GetCustomer", cust);
        }

        public IActionResult EditCustomer(Customer c)
        {
            if(!ModelState.IsValid)
            {
                return View("GetCustomer");
            }
            var cust = _context.Customers.Find(c.CustomerId);
            cust.CustomerName = c.CustomerName;
            cust.CustomerLastName = c.CustomerLastName;
            cust.CustomerCity = c.CustomerCity;
            cust.CustomerEmail = c.CustomerEmail;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult CustSaleMoves(int id)
        {
            var values = _context.SalesMoves.Where(x => x.CustomerId == id)
            .Include(x => x.Employee)
            .Include(x => x.Product)
            .ToList();
            var custName = _context.Customers.Where(x => x.CustomerId == id).Select(y => y.CustomerName + " " + y.CustomerLastName).FirstOrDefault();
            ViewBag.cName = custName;
            return View(values);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}