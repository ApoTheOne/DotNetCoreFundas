using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreFunda.Controller
{
    [Route("[controller]/[action]")]
    public class AboutController
    {
        public string Index()
        {
            return "Index method";
        }

        public string OfficeAddress()
        {
            return "Complete Office Address - Lorem Ipsum";
        }

        public string HomeAddress()
        {
            return "Complete Home Address - Lorem Ipsum";
        }
    }
}
