using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetCoreFunda.Model;

namespace DotNetCoreFunda.Services
{
    public class HardCodedEmployees : IEmployeeData
    {
        List<Employee> _employees;
        public HardCodedEmployees()
        {
            _employees = new List<Employee>
            {
                new Employee(){Id=1, Name="Tom Hanks"},
                new Employee(){Id=2, Name="John Travolta"}
            };
        }

        public IEnumerable<Employee> GetAll()
        {
            return _employees;
        }
    }
}
