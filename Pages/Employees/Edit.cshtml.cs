using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DotNetCoreFunda.Services;
using DotNetCoreFunda.Model;

namespace DotNetCoreFunda.Pages.Employees
{
    public class EditModel : PageModel
    {
        private readonly IEmployeeData dataService;
        [BindProperty]
        public Employee Employee { get; set; }
        public EditModel(IEmployeeData dataService)
        {
            this.dataService = dataService;
        }
        public IActionResult OnGet(int id )
        {
            Employee = dataService.Get(id);
            if (Employee == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if(ModelState.IsValid)
            {
                Employee = dataService.Update(Employee);
                return RedirectToAction("Details", "Home", new {id = Employee.Id });
            }
            return Page();

        }
    }
}