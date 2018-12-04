using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using csharpanimalshelter.Models;

namespace csharpanimalshelter.Controllers
{
    public class AnimalsController : Controller
    {

        [HttpGet("/animals")]
        public ActionResult Index()
        {
            List<Animals> allAnimals = Animals.GetAll();
            return View(allAnimals);
        }

        [HttpGet("/animals/new")]
        public ActionResult New()
        {
            
          
            return View();
        }

        [HttpPost("/animals/new")]
         public ActionResult Create(string animalType, string animalName, string animalBreed, string animalDate)
        {
            Animals myAnimal = new Animals(animalType,animalName,animalBreed,animalDate);
            myAnimal.Save();

             List<Animals> allAnimals = Animals.GetAll();
            return View("Index", allAnimals);
        }

        [HttpGet("animals/{name}")]
        public ActionResult Show(string name)
        {
         Animals currentAnimal = Animals.GetAnimal(name);  

         return View("Show", currentAnimal);
        }
    }
}
