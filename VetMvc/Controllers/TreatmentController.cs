using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VetMvc.Data;
using VetMvc.Models;
namespace VetMvc.Controllers
{
    public class TreatmentController : BaseController
    {
        private readonly AppDbContext _context;

        public TreatmentController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Treatments
                .Include(t => t.Pet)
                .Include(t => t.Employee)
                .Include(t => t.Medicine)
                .ToList());
        }

        public IActionResult EditCreate(int id = 0)
        {
            ViewBag.Pets = _context.Pets.ToList();           
            ViewBag.Employees = _context.Employees.ToList(); 
            ViewBag.Medicines = _context.Medicines.ToList(); 

            if (id == 0)
                return View();
            else
                return View(_context.Treatments.Find(id));
        }

        [HttpPost]
        public IActionResult EditCreate(TreatmentModel treatment)
        {
            if (treatment.TreatmentId == 0)
                _context.Treatments.Add(treatment);
            else
                _context.Treatments.Update(treatment);

            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var treatment = _context.Treatments.Find(id);
            if (treatment != null)
            {
                _context.Treatments.Remove(treatment);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult SearchByDate(DateTime date)
        {
            var result = _context.Treatments
                .Include(t => t.Pet)
                .Include(t => t.Employee)
                .Include(t => t.Medicine)
                .Where(t => t.TreatmentDate == date)
                .ToList();
            return View("Index", result);
        }

        public IActionResult SearchByPetName(string keyword)
        {
            var result = _context.Treatments
                .Include(t => t.Pet)
                .Include(t => t.Employee)
                .Include(t => t.Medicine)
                .Where(t => t.Pet.PetName.StartsWith(keyword))
                .ToList();
            return View("Index", result);
        }

        public IActionResult SearchByPetType(string keyword)
        {
            var result = _context.Treatments
                .Include(t => t.Pet)
                .Include(t => t.Employee)
                .Include(t => t.Medicine)
                .Where(t => t.Pet.PetType.StartsWith(keyword))
                .ToList();
            return View("Index", result);
        }

        public IActionResult SearchByDoctorName(string keyword)
        {
            var result = _context.Treatments
                .Include(t => t.Employee)
                .Include(t => t.Pet)
                .Include(t => t.Medicine)
                .Where(t => t.Employee.NameSurname.StartsWith(keyword))
                .ToList();
            return View("Index", result);
        }


    }
}
