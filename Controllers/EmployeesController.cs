using System.Linq;
using DemoApplication1.Data;
using DemoApplication1.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoApplication1.Controllers
{
    public class EmployeesController : Controller
     {
          private readonly ApplicationDbContext _context;
          public EmployeesController(ApplicationDbContext context)
          {
               _context = context;
          }

          public IActionResult Index()
          {
               var employees = _context.Employees.ToList();
               return View(employees);
          }

          [HttpGetAttribute]
          public IActionResult Detail(int Id)
          {
               var employees = _context.Employees.FirstOrDefault(ee => ee.Id == Id);
               return View(employees);
          }
          [HttpGetAttribute]
          public IActionResult Create()
          {
               return View();
          }
          [HttpPostAttribute]
          public IActionResult Create(Employee model)
          {
               if (ModelState.IsValid)
               {
                    var createEmployee = _context.Employees.Add(model);
                    return View(createEmployee);
               }

               return View();


          }


     }
}