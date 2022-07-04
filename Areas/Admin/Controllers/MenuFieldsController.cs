using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using MovieAspCore.Domain;
using MovieAspCore.Domain.Entities;

namespace MovieAspCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MenuFieldsController : Controller
    {
        private readonly General managerDB;
        private readonly IWebHostEnvironment hostingEnvironment;
        public MenuFieldsController(General managerDB, IWebHostEnvironment hostingEnvironment)
        {
            this.managerDB = managerDB;
            this.hostingEnvironment = hostingEnvironment;
        }
       
        public IActionResult Edit(int id)
        {
            var entity = id == default ? new MenuField() : managerDB.MenuReposit.GetOne(id);

            return View(entity);
        }
        
        [HttpPost]
        public IActionResult Edit(MenuField model)
        {
            if (ModelState.IsValid)
            {
                managerDB.MenuReposit.ChangeSave(model);
                return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).Replace("Controller", ""));
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            managerDB.MenuReposit.Delete(id);
            return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).Replace("Controller", ""));
        }
    }
}
