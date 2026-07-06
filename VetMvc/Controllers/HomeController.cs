using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VetMvc.Data;
using VetMvc.Models;

namespace VetMvc.Controllers
{
    public class HomeController : BaseController
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.TotalEmployees = _context.Employees.Count();
            ViewBag.TotalPets = _context.Pets.Count();
            ViewBag.TotalMedicines = _context.Medicines.Count();
            ViewBag.TotalTreatments = _context.Treatments.Count();

            ViewBag.TreatmentsByMonth = _context.Treatments
                .Where(t => t.TreatmentDate.HasValue)
                .GroupBy(t => new { t.TreatmentDate.Value.Year, t.TreatmentDate.Value.Month })
                .Select(g => new { g.Key.Year, g.Key.Month, Total = g.Count() })
                .OrderBy(x => x.Year).ThenBy(x => x.Month)
                .ToList();

            return View();
        }
    }
}