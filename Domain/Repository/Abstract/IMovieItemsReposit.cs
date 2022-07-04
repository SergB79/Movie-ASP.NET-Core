using System.Linq;
using MovieAspCore.Domain.Entities;

namespace MovieAspCore.Domain.Repository.Abstract
{
    public interface IMovieItemsReposit
    {
        IQueryable<MovieItem> GetAll();
        MovieItem GetOne(int id);
        void Delete(int id);
        void ChangeSave(MovieItem entity);
    }
}
