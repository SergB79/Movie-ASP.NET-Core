using Microsoft.AspNetCore.Mvc;
using MovieAspCore.Domain;

namespace MovieAspCore.Controllers
{
    public class ShowMenu : Controller
    {
        private readonly General managerDB;
        public ShowMenu(General managerDB)
        {
            this.managerDB = managerDB;
        }
        public IActionResult Index(int id)
        {
            if (id != default)
            {
                return View("Show", managerDB.MenuReposit.GetOne(id));
            }
            return View("~/Views/Home/Index.cshtml", managerDB.MovieReposit.GetAll());
        }
    }
}
