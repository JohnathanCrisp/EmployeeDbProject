using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProject6.Data;
using FinalProject6.Models;
using FinalProject6.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject6.Controllers
{

    public class EmployeesController : Controller
    {
        

        private EmployeeDbContext context;

        public EmployeesController(EmployeeDbContext dbContext)
        {
            context = dbContext;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Employee> employees = context.Employees.ToList();

            return View(employees);
        }

        public IActionResult Add()
        {
            AddEmployeeViewModel addEmployeeViewModel = new AddEmployeeViewModel();

            return View(addEmployeeViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddEmployeeViewModel addEmployeeViewModel)
        {
            if (ModelState.IsValid)
            {
                Employee newEmployee = new Employee
                {
                    Name = addEmployeeViewModel.Name,
                    Skill = addEmployeeViewModel.Skill,
                    Hobby = addEmployeeViewModel.Hobby,
                    Type = addEmployeeViewModel.Type
                };

                context.Employees.Add(newEmployee);
                context.SaveChanges();

                return Redirect("/Employees");
            }

            return View(addEmployeeViewModel);
        }

        public IActionResult Delete()
        {
            ViewBag.employees = context.Employees.ToList();
            

            return View();
        }

        

        [HttpPost]
        public IActionResult Delete(int[] employeeIds)
        {
            foreach (int employeeId in employeeIds)
            {
                Employee theEmployee = context.Employees.Find(employeeId);
                context.Employees.Remove(theEmployee);
            }

            context.SaveChanges();

            return Redirect("/Employees");
        }


        public ViewResult Update(int id)
        {
            Employee employee = context.Employees.Find(id);

            UpdateEmployeeViewModel updateEmployeeViewModel = new UpdateEmployeeViewModel
            {
                Id = employee.Id,
                Name = employee.Name,
                Skill = employee.Skill,
                Hobby = employee.Hobby,
                Type = employee.Type
            };
            return View(updateEmployeeViewModel);
        }

        [HttpPost]
        public IActionResult Update(UpdateEmployeeViewModel model)
        {
            {
                if (ModelState.IsValid)
                {
                    {
                        Employee TheEmployee = context.Employees.Find(model.Id);
                        TheEmployee.Name = model.Name;
                        TheEmployee.Skill = model.Skill;
                        TheEmployee.Hobby = model.Hobby;
                        TheEmployee.Type = model.Type;

                        context.Employees.Update(TheEmployee);
                        context.SaveChanges();
                        return Redirect("/Employees");
                        
                        /*Name = UpdateEmployeeViewModel.Name,
                        Skill = UpdateEmployeeViewModel.Skill,
                        Hobby = UpdateEmployeeViewModel.Hobby,
                        Type = UpdateEmployeeViewModel.Type*/
                    };

                    /*context.Employees.Update(TheEmployee);
                    context.SaveChanges();*/

                    /*return Redirect("/Employees");*/
                }

                return View();
            }
        }
    }
}
