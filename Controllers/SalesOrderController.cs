using LTMKarur.Data;
using LTMKarur.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LTMKarur.Controllers
{
    public class SalesOrderController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SalesOrderController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var orders = await _context.SalesOrders
                .Include(o => o.Customer)
                .Include(o => o.SalesOrderCertifications)
                .ThenInclude(c => c.Certification)
                .ToListAsync();
            return View(orders);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new SalesOrder
            {
                SeriesID = GenerateSeriesID(),
                OrderDate = DateTime.Today,
                DeliveryDate = DateTime.Today
            };

            ViewBag.Customers = _context.CustomerMasters.ToList();
            ViewBag.Certifications = _context.Certifications.ToList();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SalesOrder model, List<SalesOrderItem> items, int[] selectedCertifications)
        {
            if (model.OrderDate > model.DeliveryDate)
            {
                ModelState.AddModelError("OrderDate", "Sales Order date cannot be after Delivery Date.");
            }

            if (!ModelState.IsValid)
            {
                ViewBag.Customers = _context.CustomerMasters.ToList();
                ViewBag.Certifications = _context.Certifications.ToList();
                return View(model);
            }

            _context.SalesOrders.Add(model);
            await _context.SaveChangesAsync();

            // ✅ Save items
            foreach (var item in items)
            {
                item.SalesOrderId = model.Id;
                _context.SalesOrderItems.Add(item);
            }

            // ✅ Save selected certifications
            foreach (var certId in selectedCertifications)
            {
                _context.SalesOrderCertifications.Add(new SalesOrderCertification
                {
                    SalesOrderId = model.Id,
                    CertificationId = certId
                });
            }

            await _context.SaveChangesAsync();

            TempData["Success"] = "Sales Order created successfully.";
            return RedirectToAction(nameof(Index));
        }

        private string GenerateSeriesID()
        {
            var lastOrder = _context.SalesOrders.OrderByDescending(o => o.Id).FirstOrDefault();
            int nextNum = lastOrder == null ? 1 : lastOrder.Id + 1;
            return $"SO-{nextNum:D4}";
        }
    }
}
