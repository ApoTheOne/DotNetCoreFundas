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

        public Employee Add(Employee newEmp)
        {
            newEmp.Id = _employees.Max(x => x.Id) + 1;
            _employees.Add(newEmp);
            return newEmp;
        }

        public Employee Get(int id)
        {
            return _employees.FirstOrDefault(e => e.Id == id);
        }

        public IEnumerable<Employee> GetAll()
        {
            return _employees;
        }

        public Employee Update(Employee emp)
        {
            throw new NotImplementedException();
        }
    }
}
