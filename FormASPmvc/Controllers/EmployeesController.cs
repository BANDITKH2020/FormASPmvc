using FormASPmvc.Data;
using FormASPmvc.Models;
using FormASPmvc.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace FormASPmvc.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly MVCDemoDbContext mvcDemoDbContext;

        public EmployeesController(MVCDemoDbContext mvcDemoDbContext)
        {
            this.mvcDemoDbContext = mvcDemoDbContext;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        
        public async Task<IActionResult> Add(AddEmployeeViewModel addEmployeeRequest)
        {

            var employee =  new Employee();
            {
                Guid Id = Guid.NewGuid();
                String Name = addEmployeeRequest.Name;
                String Email = addEmployeeRequest.Email;
                long Salary = addEmployeeRequest.Salary;
                String Department = addEmployeeRequest.Department;
                DateTime DateOfBirth = addEmployeeRequest.DateofBirth;
            };

            await mvcDemoDbContext.Employees.AddAsync(employee);
            await mvcDemoDbContext.SaveChangesAsync();
            return RedirectToAction("Add");
        }





    }
}
