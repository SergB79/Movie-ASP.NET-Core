using Microsoft.AspNetCore.Mvc;
using MovieAspCore.Domain;
using System.ComponentModel.DataAnnotations;

namespace MovieAspCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly General managerDB;
        public HomeController(General managerDB)
        {
            this.managerDB = managerDB;
        }
        public IActionResult Index()
        {
            return View(managerDB);
        }
    }
}
