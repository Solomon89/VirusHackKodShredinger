using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace VirusHackKodShredinger.Controllers
{
    public class StudsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult VideoConference(int? id)
        {
            return View();
        }
        public IActionResult ProffesorRoom(int? id)
        {

            return View();
        }
        public IActionResult CheckEyes()
        {
            return View();
        }
    }
}