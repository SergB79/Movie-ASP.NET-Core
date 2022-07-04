using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieAspCore.Domain;
using MovieAspCore.Domain.Entities;

namespace MovieAspCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MovieItemsController : Controller
    {
        private readonly General managerDB;
        private readonly IWebHostEnvironment hostingEnvironment;
        public MovieItemsController(General managerDB, IWebHostEnvironment hostingEnvironment)
        {
            this.managerDB = managerDB;
            this.hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Edit(int id)
        {
            var entity = id == default ? new MovieItem() : managerDB.MovieReposit.GetOne(id);

            return View(entity);
        }
        [HttpPost]
        public IActionResult Edit(MovieItem model, IFormFile titleImageFile)
        {
            if (ModelState.IsValid)
            {
                if (titleImageFile != null)
                {
                    model.TitleImagePath = titleImageFile.FileName;
                    using (var stream = new FileStream(Path.Combine(hostingEnvironment.WebRootPath, "images/", titleImageFile.FileName), FileMode.Create))
                    {
                        titleImageFile.CopyTo(stream);
                    }
                }
                managerDB.MovieReposit.ChangeSave(model);
                return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).Replace("Controller", ""));
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            managerDB.MovieReposit.Delete(id);
            return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).Replace("Controller", ""));
        }

    }
}
