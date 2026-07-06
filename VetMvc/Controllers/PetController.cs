using Microsoft.AspNetCore.Mvc;
using VetMvc.Data;
using VetMvc.Models;
namespace VetMvc.Controllers
{
    public class PetController : BaseController
    {
        private readonly AppDbContext _context;
        public PetController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Pets.ToList());
        }
        public IActionResult EditCreate(int id = 0)
        {
            if (id == 0)
                return View();
            else
                return View(_context.Pets.Find(id));
        }

        [HttpPost]
        public IActionResult EditCreate(PetModel pet)
        {
            if (pet.PetId == 0)
                _context.Pets.Add(pet);
            else
                _context.Pets.Update(pet);

            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var pet = _context.Pets.Find(id);
            if (pet != null)
            {
                _context.Pets.Remove(pet);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult SearchByName(string keyword)
        {
            var result = _context.Pets
                .Where(e => e.PetName.StartsWith(keyword))
                .ToList();
            return View("Index", result);
        }

        public IActionResult SearchByType(string keyword)
        {
            var result = _context.Pets
                .Where(e => e.PetType.StartsWith(keyword))
                .ToList();
            return View("Index", result);
        }
    }
    
}
