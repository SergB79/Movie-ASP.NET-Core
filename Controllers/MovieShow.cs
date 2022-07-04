using Microsoft.AspNetCore.Mvc;
using MovieAspCore.Domain;

namespace MovieAspCore.Controllers
{
    public class MovieShow : Controller
    {
        private readonly General managerDB;
        public MovieShow(General managerDB)
        {
            this.managerDB = managerDB;
        }
        public IActionResult Index(int id)
        {
            if (id != default)
            {
                return View("Show", managerDB.MovieReposit.GetOne(id));
            }
            return View("~/Views/Home/Index.cshtml", managerDB.MovieReposit.GetAll());
        }
    }
}
