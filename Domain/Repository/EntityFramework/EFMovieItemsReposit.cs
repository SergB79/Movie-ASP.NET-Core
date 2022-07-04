using System.Linq;
using Microsoft.EntityFrameworkCore;
using MovieAspCore.Domain.Repository.Abstract;
using MovieAspCore.Domain.Entities;

namespace MovieAspCore.Domain.Repository.EntityFramework
{
    public class EFMovieItemsReposit: IMovieItemsReposit
    {
        private readonly MovieContext context;
        public EFMovieItemsReposit (MovieContext context)
        {
            this.context = context;
        }
        public IQueryable<MovieItem> GetAll()
        {
            return context.MovieItems;
        }

        public MovieItem GetOne (int id)
        {
            return context.MovieItems.FirstOrDefault(m=>m.Id==id);
        }

        public void Delete (int id)
        {
            MovieItem delMovie = context.MovieItems.Find(id);
            context.MovieItems.Remove(delMovie);
            context.SaveChanges();
        }

        public void ChangeSave(MovieItem entity)
        {
            if (entity.Id == default)
                context.Entry(entity).State = EntityState.Added;
            else
                context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }
            
    }
}
