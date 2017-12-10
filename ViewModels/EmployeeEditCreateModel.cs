using DotNetCoreFunda.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreFunda.ViewModels
{
    public class EmployeeEditCreateModel
    {
        [Required, Display(Name = "Employee Name"), MaxLength(50)]
        public string Name { get; set; }
        public EmployeeType EmpType { get; set; }
    }
}
