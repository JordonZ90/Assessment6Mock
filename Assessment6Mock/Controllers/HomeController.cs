using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Assessment6Mock.Models;
using System.Security.Claims;

namespace Assessment6Mock.Controllers
{
    public class HomeController : Controller
    {
        private readonly EmployeeDbContext _context; // NEED this

        public HomeController(EmployeeDbContext context)
        {
            _context = context;
        }
        public IActionResult Employee()
        {
            return View(_context.Employee.ToList());
        }
        public IActionResult RetirementInfo(int Id)
        {
            Employee findEmployee = _context.Employee.Find(Id);
            if (findEmployee.Age > 60)
            {
                ViewBag.CanRetire = true;
            }
            else
            {
                ViewBag.CanRetire = false;
                //return RedirectToAction("SomeOtherAction");
            }
            ViewBag.Benefits = findEmployee.Salary * 0.6; //(double)findEmployee.Salary * 0.6;
            return View();
        }
        [HttpGet]
        public IActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddEmployee(Employee newEmployee)
        {
            // strictly identity
            //newEmployee.Id = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            if (ModelState.IsValid)
            {
                _context.Employee.Add(newEmployee);
                _context.SaveChanges();

                return RedirectToAction("Employee");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
