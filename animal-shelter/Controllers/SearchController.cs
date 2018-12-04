using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using csharpanimalshelter.Models;

namespace csharpanimalshelter.Controllers
{
    public class SearchController : Controller
    {
        [HttpGet("animals/search")]
        public ActionResult Search()
        {
          return View();
        }

        [HttpPost("animals/search")]
        public ActionResult Show(string animalType)
        {
            List<Animals> allAnimalsByType = Animals.GetByType(animalType);
            return View(allAnimalsByType);
         
        }
        
    }
}