using Microsoft.AspNetCore.Mvc;
using SampleProject.Models;

namespace SampleProject.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public List<Employee> GetEmployees()
        {
            EmployeeRepository er = new EmployeeRepository();
            
            return er.GetAllEmployees();
        }
/*        public Employee GetEmployeeByID(int id)
        {
            EmployeeRepository er = new EmployeeRepository();
            return 
;            
        }*/

        public IActionResult GetEmployeeByID(int id)
        {
            EmployeeRepository er = new EmployeeRepository();
            Employee emp = er.GetEmployeeByID(id);
            //ViewData["emp"] = emp;
            ViewBag.employee = emp; 
            return View();
        }
    }
}
