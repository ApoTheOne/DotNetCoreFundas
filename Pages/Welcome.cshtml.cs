using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DotNetCoreFunda.Services;

namespace DotNetCoreFunda.Pages
{
    public class WelcomeModel : PageModel
    {
        private readonly IGreeter _greeter;
        public string GreetingMessage { get; set; }
        public WelcomeModel(IGreeter greeter)
        {
            this._greeter = greeter;
        }
        public void OnGet(string name)
        {
            GreetingMessage = $"{name} : {_greeter.GetMessage()}";
        }
    }
}