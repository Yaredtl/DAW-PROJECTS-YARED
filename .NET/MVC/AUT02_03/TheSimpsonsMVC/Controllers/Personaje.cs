//using AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Matching;
using System.Diagnostics.Eventing.Reader;
using TheSimpsonsMVC.Models;

namespace TheSimpsonsMVC.Controllers
{
    public class Personaje : Controller
    {
        public static int numlista = 3;
		public IActionResult Index()
        {
            return View(personajes);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create( Character personaje )
        {
            
            if (ModelState.IsValid) 
            {   
					var pj = new Character()
					{
						Id = numlista++,
						name = personaje.name,
						age = personaje.age,
						job = personaje.job
					};
					personajes.Add(pj);
					return RedirectToAction("Index");        
			}
            return View(personaje);
		}
        public IActionResult Delete(int num) 
        {
            for (int i = 0; i <= personajes.Count - 1; i++)
            {
                if (personajes[i].Id == num)
                {
                    personajes.Remove(personajes[i]);
                    break;
                }
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Update(int num)
        {
			for (int i = 0; i <= personajes.Count - 1;i++)
			{
				if (personajes[i].Id == num)
				{
					return View(personajes[i]);
             
				}
			}
			return View();
		}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Character personaje)
        {
            if (ModelState.IsValid) 
            {
				for (int i = 0; i <= personajes.Count - 1; i++)
				{
					if (personajes[i].Id == personaje.Id)
					{
                        personajes[i].name = personaje.name;
						personajes[i].age = personaje.age;
						personajes[i].job = personaje.job;   
					}
				}
				return RedirectToAction("Index");
			}
			return View(personaje);
			
        }
        public static List<Character> personajes = new List<Character>
        {
            new Character
            {
                Id = 1,
                name = "Bart",
               age = 8,
               job = "Student"
            },
            new Character
            {
                Id = 2,
                name = "Marge",
                age = 34,
                job = "Housewife"
            }
        };
        public IActionResult Show(int num)
        {
            for (int i = personajes.Count - 1; i >= 0; i--)
            {
                if (personajes[i].Id == num)
                {
                    return View(personajes[i]);
                }
            }
            return View();

        }
    }
   
}