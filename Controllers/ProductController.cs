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
    public class ProductController : Controller
    {
        private readonly Context _context;

        public ProductController(Context context){

            _context = context;
        }

        public IActionResult Index()
        {
            var products = _context.Products.Where(p => p.Condition == true)
            .Include(p => p.Category)
            .ToList();
            return View(products);
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            List<SelectListItem> values = (from x in _context.Categories.ToList()
                                          select new SelectListItem
                                          {
                                            Text = x.CategoryName,
                                            Value = x.CategoryId.ToString()
                                          }).ToList();
            ViewBag.value1 = values;
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(Product p)
        {
            _context.Products.Add(p);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult RemoveProduct(int id)
        {
            var rProduct = _context.Products.Find(id);
            rProduct.Condition = false;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult GetProduct(int id)
        {
            List<SelectListItem> values = (from x in _context.Categories.ToList()
                                          select new SelectListItem
                                          {
                                            Text = x.CategoryName,
                                            Value = x.CategoryId.ToString()
                                          }).ToList();
            ViewBag.value1 = values;

            var product = _context.Products.Find(id);
            return View("GetProduct", product);
        }

        public IActionResult EditProduct(Product p)
        {
            var product = _context.Products.Find(p.ProductId);

            product.ProductName = p.ProductName;
            product.Brand = p.Brand;
            product.Stock = p.Stock;
            product.PurchasePrice = p.PurchasePrice;
            product.SalePrice = p.SalePrice;
            product.Condition = p.Condition;
            product.ProductImage = p.ProductImage;
            product.CategoryId = p.CategoryId;
            
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult ProductList(int id)
        {
            var value = _context.Products.Include(p => p.Category).ToList();
            return View(value);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}