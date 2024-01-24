using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineCommercialAutomation.Models.Classes;

namespace OnlineCommercialAutomation.Controllers
{
    public class ProductDetailController : Controller
    {
        private readonly Context _context;

        public ProductDetailController(Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            TableRelation relation = new TableRelation();

            relation.ProductValue = _context.Products.Where(x => x.ProductId == 1).ToList();
            relation.DetailValue = _context.Details.Where(y => y.DetailId == 1).ToList();
            
            return View(relation);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}