using System.Linq;
using Microsoft.EntityFrameworkCore;
using MovieAspCore.Domain.Repository.Abstract;
using MovieAspCore.Domain.Entities;

namespace MovieAspCore.Domain.Repository.EntityFramework
{
    public class EFMenuFieldsReposit:IMenuFieldsReposit
    {
        private readonly MovieContext context;
        public EFMenuFieldsReposit(MovieContext context)
        {
            this.context = context;
        }
        public IQueryable<MenuField> GetAll()
        {
            return context.MenuFields;
        }

        public MenuField GetOne(int id)
        {
            return context.MenuFields.FirstOrDefault(m => m.Id == id);
        }

        public MenuField GetCodeWord(string codeword)
        {
            return context.MenuFields.FirstOrDefault(m => m.CodeWord == codeword);
        }

        public void Delete(int id)
        {
            MenuField delMovie = context.MenuFields.Find(id);
            if (delMovie != null)
            {
                context.MenuFields.Remove(delMovie);
                context.SaveChanges();
            }
        }

        public void ChangeSave(MenuField entity)
        {
            if (entity.Id == default)

                context.Entry(entity).State = EntityState.Added;
            else
                context.Entry(entity).State = EntityState.Modified;
            entity.CodeWord = "Page" + entity.Id.ToString();
            context.SaveChanges();
        }
    }
}
