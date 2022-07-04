using System.Threading.Tasks;
using MovieAspCore.Domain;
using Microsoft.AspNetCore.Mvc;


namespace MovieAspCore.Models
{
    public class MenuViewsModel:ViewComponent
    {
        private readonly General managerDB;
        public MenuViewsModel (General managerDB)
        {
            this.managerDB = managerDB;
        }

        public Task<IViewComponentResult> InvokeAsync()
        {
            return Task.FromResult((IViewComponentResult)View("Menu", managerDB.MenuReposit.GetAll()));
        }
    }
}
