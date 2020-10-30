using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using FinalProject6.Models;

namespace FinalProject6.ViewModels
{
    public class AddEmployeeViewModel
    {
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [StringLength(500, ErrorMessage = "Description too long!")]
        public string Skill { get; set; }


        public string Hobby { get; set; }

        public EmployeeType Type { get; set; }

        public List<SelectListItem> EmployeeTypes { get; set; } = new List<SelectListItem>
        {
            new SelectListItem(EmployeeType.Intern.ToString(), ((int)EmployeeType.Intern).ToString()),
            new SelectListItem(EmployeeType.Manager.ToString(), ((int)EmployeeType.Manager).ToString()),
            new SelectListItem(EmployeeType.CEO.ToString(), ((int)EmployeeType.CEO).ToString()),
            new SelectListItem(EmployeeType.Salesman.ToString(), ((int)EmployeeType.Salesman).ToString())
        };

    }
}
