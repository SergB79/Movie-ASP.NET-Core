using MovieAspCore.Domain.Repository.Abstract;

namespace MovieAspCore.Domain
{
    public class General
    {
        public IMenuFieldsReposit MenuReposit { get; set; }
        public IMovieItemsReposit MovieReposit { get; set; }
        public General(IMenuFieldsReposit menuFields, IMovieItemsReposit movieItems)
        {
            MenuReposit = menuFields;
            MovieReposit = movieItems;
        }              
    }
}
