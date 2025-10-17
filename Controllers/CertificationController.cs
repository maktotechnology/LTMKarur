using LTMKarur.Data;
using LTMKarur.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LTMKarur.Controllers
{
    [Route("[controller]/[action]")]
    public class CertificationController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CertificationController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var certifications = await _context.Certifications.ToListAsync();
            return View(certifications);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Certification model)
        {
            if (string.IsNullOrWhiteSpace(model.Name))
                return BadRequest();

            _context.Certifications.Add(new Certification { Name = model.Name });
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Update([FromBody] Certification model)
        {
            var cert = await _context.Certifications.FindAsync(model.Id);
            if (cert == null || string.IsNullOrWhiteSpace(model.Name))
                return NotFound();

            cert.Name = model.Name;
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] Certification model)
        {
            var cert = await _context.Certifications.FindAsync(model.Id);
            if (cert == null)
                return NotFound();

            _context.Certifications.Remove(cert);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
