using LTMKarur.Data;
using LTMKarur.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LTMKarur.Controllers
{
    public class ItemMasterController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ItemMasterController(ApplicationDbContext context) => _context = context;

        public async Task<IActionResult> Index()
        {
            var items = await _context.ItemMasters.ToListAsync();
            return View(items);
        }

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ItemMaster model)
        {
            if (ModelState.IsValid)
            {
                _context.ItemMasters.Add(model);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Item created successfully.";
                return RedirectToAction(nameof(Index));
            }

            TempData["Error"] = "Please fill all mandatory fields.";
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var item = await _context.ItemMasters.FindAsync(id);
            if (item == null) return NotFound();
            return View(item);
        }

        [HttpGet]
public async Task<IActionResult> Details(int id)
{
    var item = await _context.ItemMasters.FirstOrDefaultAsync(i => i.Id == id);
    if (item == null)
        return NotFound();

    return View(item);
}


        [HttpGet]
public async Task<IActionResult> GetCounts(string term)
{
    var results = await _context.CountMasters
        .Where(c => c.CountName.Contains(term))
        .Select(c => c.CountName.Replace("s", ""))
        .Distinct()
        .Take(10)
        .ToListAsync();

    return Json(results);
}


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ItemMaster model)
        {
            if (ModelState.IsValid)
            {
                _context.Update(model);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Item updated successfully.";
                return RedirectToAction(nameof(Index));
            }
            TempData["Error"] = "Update failed.";
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _context.ItemMasters.FindAsync(id);
            if (item == null) return NotFound();

            _context.ItemMasters.Remove(item);
            await _context.SaveChangesAsync();

            TempData["Success"] = "Item deleted successfully.";
            return RedirectToAction(nameof(Index));
        }
    }
}
