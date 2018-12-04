using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using csharpanimalshelter.Models;

namespace csharpanimalshelter.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("/")]
        public ActionResult Index()
        {
           
            return View();
        }
        
        
    }
}
