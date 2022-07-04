using System.ComponentModel.DataAnnotations;

namespace MovieAspCore.Domain.Entities
{
    public class MovieItem : EntityBase
    {
        [Required(ErrorMessage = "Заполните название фильма")]
        [Display(Name = "Название фильма")]
        public override string Title { get; set; }

        [Display(Name = "Жанр")]
        public override string Janre { get; set; }

        [Display(Name = "Год выпуска")]
        public override string Year { get; set; }

        [Display(Name = "Полное описание фильма")]
        public override string Text { get; set; }
    }
}
