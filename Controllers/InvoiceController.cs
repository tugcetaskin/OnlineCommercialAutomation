using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace OnlineCommercialAutomation.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly Context _context;

        public InvoiceController(Context context){

            _context = context;
        }

        public IActionResult Index()
        {
            var list = _context.Invoices.ToList();
            return View(list);
        }

        [HttpGet]
        public IActionResult AddInvoice()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddInvoice(Invoice invoice)
        {
            invoice.InvoiceDate = DateTime.Now.Date;
            invoice.Time = DateTime.Now.ToString("HH:mm");
            _context.Invoices.Add(invoice);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult GetInvoice(int id)
        {
            var invoice = _context.Invoices.Find(id);
            return View("GetInvoice", invoice);
        }

        [HttpPost]
        public IActionResult EditInvoice(Invoice invoice)
        {
            var newIn = _context.Invoices.Find(invoice.InvoiceId);
            newIn.InvoiceSerialNumber = invoice.InvoiceSerialNumber;
            newIn.InvoiceSequenceNumber = invoice.InvoiceSequenceNumber;
            newIn.InvoiceDate = invoice.InvoiceDate;
            newIn.TaxAdministration = invoice.TaxAdministration;
            newIn.Time = invoice.Time;
            newIn.Deliverer = invoice.Deliverer;
            newIn.Receiver = invoice.Receiver;

            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult InvoiceDetail(int id)
        {
            var invoice = _context.InvoiceItems.Where(x => x.InvoiceId == id).ToList();
            return View("InvoiceDetail", invoice);
        }

        [HttpGet]
        public IActionResult AddInvoiceItem()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddInvoiceItem(InvoiceItem item)
        {
            _context.InvoiceItems.Add(item);
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