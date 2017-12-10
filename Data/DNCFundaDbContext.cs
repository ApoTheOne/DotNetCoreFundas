using DotNetCoreFunda.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreFunda.Data
{
    public class DNCFundaDbContext: DbContext
    {
        public DNCFundaDbContext(DbContextOptions options):base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
    }
}
