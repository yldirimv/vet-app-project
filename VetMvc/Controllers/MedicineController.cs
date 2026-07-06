using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VetMvc.Data;
using VetMvc.Models;

namespace VetMvc.Controllers
{
    public class MedicineController : BaseController
    {

        private readonly AppDbContext _context;

        public MedicineController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Medicines.ToList());
        }

        public IActionResult EditCreate(int id = 0)
        {
            if (id == 0)
                return View();
            else
                return View(_context.Medicines.Find(id));
        }

        [HttpPost]
        public IActionResult EditCreate(MedicineModel medicine)
        {
            if (medicine.MedicineId == 0)
                _context.Medicines.Add(medicine);
            else
                _context.Medicines.Update(medicine);

            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var medicine = _context.Medicines.Find(id);
            if (medicine != null)
            {
                _context.Medicines.Remove(medicine);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult SearchByName(string keyword)
        {
            var result = _context.Medicines
                .Where(e => e.MedName.StartsWith(keyword))
                .ToList();
            return View("Index", result);
        }

        public IActionResult SearchByType(string keyword)
        {
            var result = _context.Medicines
                .Where(e => e.MedicineType.StartsWith(keyword))
                .ToList();
            return View("Index", result);
        }
    }
}
