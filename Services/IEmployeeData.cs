using DotNetCoreFunda.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreFunda.Services
{
    public interface IEmployeeData
    {
        IEnumerable<Employee> GetAll();
        Employee Get(int id);
        Employee Add(Employee newEmp);
        Employee Update(Employee emp);
    }
}
