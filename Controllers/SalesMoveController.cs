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
    public class SalesMoveController : Controller
    {
        private readonly Context _context;

        public SalesMoveController(Context context){

            _context = context;
        }

        public IActionResult Index()
        {
            var sales = _context.SalesMoves
            .Include(x => x.Product)
            .Include(x => x.Customer)
            .Include(x => x.Employee)
            .ToList();
            return View(sales);
        }

        [HttpGet]
        public IActionResult AddSale()
        {
            List<SelectListItem> value1 = (
                from x in _context.Products.ToList()
                select new SelectListItem
                {
                    Text = x.ProductName,
                    Value = x.ProductId.ToString()
                }).ToList();

            List<SelectListItem> value2 = (
                from x in _context.Customers.ToList()
                select new SelectListItem
                {
                    Text = x.CustomerName + " " + x.CustomerLastName,
                    Value = x.CustomerId.ToString()
                }).ToList();

            List<SelectListItem> value3 = (
                from x in _context.Employees.ToList()
                select new SelectListItem
                {
                    Text = x.EmployeeName + " " + x.EmployeeLastName,
                    Value = x.EmployeeId.ToString()
                }).ToList();

            ViewBag.valueP = value1;
            ViewBag.valueC = value2;
            ViewBag.valueE = value3;

            return View();
        }

        [HttpPost]
        public IActionResult AddSale(SalesMove sale)
        {
            _context.SalesMoves.Add(sale);
            sale.Date =DateTime.Parse(DateTime.Now.ToShortDateString());
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult GetSales(int id)
        {
            List<SelectListItem> value1 = (
                from x in _context.Products.ToList()
                select new SelectListItem
                {
                    Text = x.ProductName,
                    Value = x.ProductId.ToString()
                }).ToList();

            List<SelectListItem> value2 = (
                from x in _context.Customers.ToList()
                select new SelectListItem
                {
                    Text = x.CustomerName + " " + x.CustomerLastName,
                    Value = x.CustomerId.ToString()
                }).ToList();

            List<SelectListItem> value3 = (
                from x in _context.Employees.ToList()
                select new SelectListItem
                {
                    Text = x.EmployeeName + " " + x.EmployeeLastName,
                    Value = x.EmployeeId.ToString()
                }).ToList();

            ViewBag.valueP = value1;
            ViewBag.valueC = value2;
            ViewBag.valueE = value3;
            var sale = _context.SalesMoves.Find(id);
            return View("GetSales",sale);
        }

        public IActionResult EditSale(SalesMove sale)
        {
            var s = _context.SalesMoves.Find(sale.SalesId);
            s.ProductId = sale.ProductId;
            s.EmployeeId = sale.EmployeeId;
            s.CustomerId = sale.CustomerId;
            s.UnitPrice = sale.UnitPrice;
            s.Quantity = sale.Quantity;
            s.TotalAmount = sale.TotalAmount;
            s.Date = sale.Date;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult SaleDetail(int id)
        {
            var saleDetail = _context.SalesMoves
            .Include(x => x.Product)
            .Include(x => x.Customer)
            .Include(x => x.Employee)
            .Where(x => x.SalesId == id).ToList();
            return View(saleDetail);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}