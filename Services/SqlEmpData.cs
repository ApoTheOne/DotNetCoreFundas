using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetCoreFunda.Model;
using DotNetCoreFunda.Data;
using Microsoft.EntityFrameworkCore;

namespace DotNetCoreFunda.Services
{
    public class SqlEmpData : IEmployeeData
    {
        private readonly DNCFundaDbContext _context;

        public SqlEmpData(DNCFundaDbContext context)
        {
            this._context = context;
        }
        public Employee Add(Employee newEmp)
        {
            _context.Employees.Add(newEmp);
            _context.SaveChanges();
            return newEmp;
        }

        public Employee Get(int id)
        {
            return _context.Employees.FirstOrDefault(x => x.Id == id);    
        }

        //should use IQuereable if the records are in big numbers
        public IEnumerable<Employee> GetAll()
        {
            return _context.Employees.OrderBy(e => e.Name);
        }

        public Employee Update(Employee emp)
        {
            _context.Attach(emp).State = EntityState.Modified;
            _context.SaveChanges();
            return emp;
        }
    }
}
