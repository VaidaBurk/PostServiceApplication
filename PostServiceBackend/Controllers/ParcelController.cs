using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostServiceBackend.Controllers
{
    public class ParcelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
