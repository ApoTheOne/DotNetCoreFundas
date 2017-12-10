using DotNetCoreFunda.Model;
using DotNetCoreFunda.Services;
using DotNetCoreFunda.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreFunda.Controllers
{
    public class HomeController : Controller
    {
        private IEmployeeData _employeeData;
        private IGreeter _greeter;

        public HomeController(IEmployeeData employeeData, IGreeter greeter)
        {
            _employeeData = employeeData;
            _greeter = greeter;
        }
        public ActionResult Index()
        {
            //var model = new Employee() { Id = 1, Name = "Anurag" };
            //return Content("Hello from HomeController's Index method!");
            //return View(_employeeData.GetAll());
            var viewmodel = new HomeIndexViewModel()
            {
                Employees = _employeeData.GetAll(),
                TasksForToday = _greeter.GetMessage()
            };
            return View(viewmodel);
        }
    }
}
