using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject6.Models
{
    public class Employee
    {
        public string Name { get; set; }

        public string Skill { get; set; }

        public string Hobby { get; set; }

        public EmployeeType Type { get; set; }

        public int Id { get; set; }

        public Employee()
        {
        }

        public Employee(string name, string skill, string hobby)
        {
            Name = name;
            Skill = skill;
            Hobby = hobby;
        }



        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object obj)
        {
            return obj is Employee @employee &&
                   Id == @employee.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}

