using VetMvc.Data;
using VetMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace VetMvc.Controllers
{
    public class EmployeeController : BaseController
    {
        private readonly AppDbContext _context;

        public EmployeeController(AppDbContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            return View(_context.Employees.ToList());
        }

        public IActionResult EditCreate(int id = 0)
        {
            if (id == 0)
                return View();
            else
                return View(_context.Employees.Find(id));
        }

        [HttpPost]
        public IActionResult EditCreate(EmployeeModel employee)
        {
            if (employee.EmployeeId == 0)
                _context.Employees.Add(employee);
            else
                _context.Employees.Update(employee);

            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var employee = _context.Employees.Find(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult SearchByName(string keyword)
        {
            var result = _context.Employees
                .Where(e => e.NameSurname.StartsWith(keyword))
                .ToList();
            return View("Index", result);
        }

        public IActionResult SearchByBranch(string keyword)
        {
            var result = _context.Employees
                .Where(e => e.Branch.StartsWith(keyword))
                .ToList();
            return View("Index", result);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(EmployeeModel employee)
        {
            var result = _context.Employees
                .Where(e => e.Email == employee.Email && e.Password == employee.Password)
                .FirstOrDefault();

            if (result == null)
            {
                ViewBag.Error = "Email veya şifre hatalı.";
                return View();
            }

            HttpContext.Session.SetString("EmployeeId", result.EmployeeId.ToString());
            HttpContext.Session.SetString("NameSurname", result.NameSurname);
            HttpContext.Session.SetString("Branch", result.Branch);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

    }
}
