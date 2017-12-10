using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreFunda.Model
{
    public class Employee
    {
        public int Id { get; set; }
        [Required, Display(Name="Employee Name"), MaxLength(50)]
        public string Name { get; set; }
        public EmployeeType EmployeeType { get; set; }
    }
}
