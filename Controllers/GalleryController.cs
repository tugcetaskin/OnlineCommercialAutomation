using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace OnlineCommercialAutomation.Controllers
{
    public class GalleryController : Controller
    {
        private readonly Context _context;

        public GalleryController(Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var values = _context.Products.ToList();
            return View(values);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}