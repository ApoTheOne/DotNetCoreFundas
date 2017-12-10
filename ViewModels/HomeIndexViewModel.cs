using DotNetCoreFunda.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreFunda.ViewModels
{
    public class HomeIndexViewModel
    {
        public IEnumerable<Employee> Employees { get; set; }
        public string TasksForToday { get; set; }
    }
}
