using Microsoft.AspNetCore.Mvc;
using LTMKarur.Data;
using LTMKarur.Models;
using Microsoft.EntityFrameworkCore;

namespace LTMKarur.Controllers;

public class CountMasterController : Controller
{
    private readonly ApplicationDbContext _context;
    public CountMasterController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var data = await _context.CountMasters.OrderBy(x => x.Id).ToListAsync();

        // UOM options can be passed via ViewBag
        ViewBag.UOMOptions = new List<string> { "Kg", "Meter", "Cone", "Hank", "Piece" };

        return View(data);
    }

    [HttpPost]
    public async Task<IActionResult> Save([FromBody] CountMaster model)
    {
        if (!ModelState.IsValid)
            return BadRequest("Invalid input");

        if (model.Id == 0)
            _context.CountMasters.Add(model);
        else
            _context.CountMasters.Update(model);

        await _context.SaveChangesAsync();
        return Ok(new { id = model.Id });
    }

    [HttpPost]
    public async Task<IActionResult> Delete([FromBody] int id)
    {
        var record = await _context.CountMasters.FindAsync(id);
        if (record == null)
            return NotFound();

        _context.CountMasters.Remove(record);
        await _context.SaveChangesAsync();
        return Ok();
    }
}
