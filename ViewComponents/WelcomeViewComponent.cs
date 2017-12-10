using DotNetCoreFunda.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreFunda.ViewComponents
{
    public class WelcomeViewComponent : ViewComponent
    {
        private readonly IGreeter greeter;

        public WelcomeViewComponent(IGreeter greeter)
        {
            this.greeter = greeter;
        }

        public IViewComponentResult Invoke()
        {
            var model = greeter.GetMessage();
            //this will be like View("viewName") as it just contains a string.
            //return View(model);
            return View("Default", model);
        }
    }
}
