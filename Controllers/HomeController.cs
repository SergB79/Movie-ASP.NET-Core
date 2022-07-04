using Microsoft.AspNetCore.Mvc;
using MovieAspCore.Domain;

namespace MovieAspCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly General managerDB;
        public HomeController (General managerDB)
        {
            this.managerDB = managerDB;
        }
        
        public IActionResult Index()
        {
             return View(managerDB.MovieReposit.GetAll());
        }
       
    }
}
