using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Authentication;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineCommercialAutomation.Models.Classes;

namespace OnlineCommercialAutomation.Controllers
{
    public class StatisticController : Controller
    {
        private readonly Context _context;

        public StatisticController(Context context){

            _context = context;
        }

        public IActionResult Index()
        {
            var value1 = _context.Customers.Count().ToString();
            ViewBag.d1 = value1;

            var value2 = _context.Products.Count().ToString();
            ViewBag.d2 = value2;

            var value3 = _context.Employees.Count().ToString();
            ViewBag.d3 = value3;

            var value4 = _context.Categories.Count().ToString();
            ViewBag.d4 = value4;

            var value5 = _context.Products.Sum(x => x.Stock).ToString();
            ViewBag.d5 = value5;

            var value6 = (from x in _context.Products select x.Brand).Distinct().Count().ToString();
            ViewBag.d6 = value6;

            var value7 = _context.Products.Count(x => x.Stock <= 20).ToString();
            ViewBag.d7 = value7;

            var value8 = (from x in _context.Products orderby x.SalePrice descending select x.ProductName).FirstOrDefault();
            ViewBag.d8 = value8;

            var value9 = (from x in _context.Products orderby x.SalePrice ascending select x.ProductName).FirstOrDefault();
            ViewBag.d9 = value9;

            var value10 = _context.Products.Count(x => x.Stock <= 20).ToString();
            ViewBag.d10 = value10;

            var value11 = _context.Products.Count(x => x.ProductName == "Buzdolabı").ToString();
            ViewBag.d11 = value11;

            var value12 = _context.Products.GroupBy(x => x.Brand).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault();
            ViewBag.d12 = value12;

            var productId = _context.SalesMoves
                            .GroupBy(x => x.ProductId)
                            .OrderByDescending(z => z.Count())
                            .Select(y => y.Key)
                            .FirstOrDefault();

            var value13 = _context.Products.Where(u => u.ProductId == productId).Select(x => x.ProductName).FirstOrDefault();
            ViewBag.d13 = value13;

            var value14 = _context.SalesMoves.Sum(x => x.TotalAmount).ToString();
            ViewBag.d14 = value14;

            DateTime today = DateTime.Today;
            var value15 = _context.SalesMoves.Count(x => x.Date == today).ToString();
            ViewBag.d15 = value15;

            var value16 = _context.SalesMoves.Where(x => x.Date == today).Sum(x => x.TotalAmount).ToString();
            ViewBag.d16 = value16;
            return View();
        }

        public IActionResult SimpleTables()
        {
            var query = from x in _context.Customers
                        group x by x.CustomerCity into GroupValue
                        select new ClassGroup
                        {
                            CityOfCustomer = GroupValue.Key,
                            NumberOfCustomer = GroupValue.Count()
                        };
            return View(query.ToList());
        }

        public PartialViewResult Partial1()
        {
            return PartialView();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}