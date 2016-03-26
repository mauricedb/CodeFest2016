using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.PlatformAbstractions;

namespace CodeFest2016.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRuntimeEnvironment _runtimeEnvironment;

        public HomeController(IRuntimeEnvironment runtimeEnvironment)
        {
            _runtimeEnvironment = runtimeEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {

            ViewData["Message"] = "Your application is running on:";
            ViewData["OperatingSystem"] = _runtimeEnvironment.OperatingSystem;
            ViewData["OperatingSystemVersion"] = _runtimeEnvironment.OperatingSystemVersion;
            ViewData["RuntimeType"] = _runtimeEnvironment.RuntimeType;
            ViewData["RuntimeArchitecture"] = _runtimeEnvironment.RuntimeArchitecture;
            ViewData["RuntimeVersion"] = _runtimeEnvironment.RuntimeVersion;

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
