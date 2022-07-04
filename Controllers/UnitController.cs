using Microsoft.AspNetCore.Mvc;
using MovieAspCore.Domain;
using MovieAspCore.Domain.Repository.Abstract;
using MovieAspCore.Domain.Entities;

namespace MovieAspCore.Controllers
{
    public class UnitController : Controller
    {
        //public IActionResult Unit()
        //{
        //    ViewData["Message"] = "Movie ASP Tests";
        //    return View("Unit");
        //}
        //private readonly General managerDB;
        //public UnitController(General managerDB)
        //{
        //    this.managerDB = managerDB;
        //}
        private readonly IMovieItemsReposit MovieReposit;
        public UnitController(IMovieItemsReposit movieReposit)
        {
            MovieReposit = movieReposit;
        }

        public IActionResult Index()
        {
            return View(MovieReposit.GetAll());
        }

        public IActionResult GetUser(int? id)
        {
            if (!id.HasValue)
                return BadRequest();
            MovieItem user = MovieReposit.GetOne(id.Value);
            if (user == null)
                return NotFound();
            return View(user);
        }
                
    }
}
