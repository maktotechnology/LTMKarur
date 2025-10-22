using LTMKarur.Data;
using LTMKarur.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LTMKarur.Controllers
{
    public class CustomerMasterController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomerMasterController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var customers = await _context.CustomerMasters.ToListAsync();
            return View(customers);
        }

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CustomerMaster model)
        {
            if (!ModelState.IsValid) return View(model);
            _context.CustomerMasters.Add(model);
            await _context.SaveChangesAsync();
            TempData["Success"] = "Customer added successfully.";
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var customer = await _context.CustomerMasters.FindAsync(id);
            if (customer == null) return NotFound();
            return View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CustomerMaster model)
        {
            if (!ModelState.IsValid) return View(model);
            _context.CustomerMasters.Update(model);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var customer = await _context.CustomerMasters.FindAsync(id);
            if (customer == null) return NotFound();
            return View(customer);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var customer = await _context.CustomerMasters.FindAsync(id);
            if (customer == null) return NotFound();
            _context.CustomerMasters.Remove(customer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
