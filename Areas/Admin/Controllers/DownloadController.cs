using Microsoft.AspNetCore.Mvc;
using MovieAspCore.Domain;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.Text;
using System;
using MovieAspCore.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAspCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DownloadController : Controller
    {
        private readonly General managerDB;
        private readonly IWebHostEnvironment appEnviron;
        public DownloadController(General managerDB, IWebHostEnvironment _appEnvirom)
        {
            this.managerDB = managerDB;
            appEnviron = _appEnvirom;
        }
                      
        [HttpPost]
        public IActionResult GetFile()
        {
            try
            {
                string pathcreate = Path.Combine(appEnviron.ContentRootPath, "wwwroot/File/Movies.txt");
                string filepath = Path.Combine("~/File", "Movies.txt");
                StreamWriter writerMovie = new StreamWriter(pathcreate, false, Encoding.UTF8);
                if (managerDB.MovieReposit.GetAll().Any())
                    foreach (MovieItem entity in managerDB.MovieReposit.GetAll())
                        writerMovie.WriteLine($"Название фильма {entity.Title} Жанр {entity.Janre} Год выпуска {entity.Year}");
                writerMovie.Close();
                return File(filepath, "text/plain", "MoviesDownload.txt");
            }
            catch (Exception)
            {
                return View("Error");
            }

        }
              
    }
}
