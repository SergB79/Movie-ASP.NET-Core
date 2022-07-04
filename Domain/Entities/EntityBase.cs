using System;
using System.ComponentModel.DataAnnotations;

namespace MovieAspCore.Domain.Entities
{
    public abstract class EntityBase
    {
        [Required]
        public int Id { get; set; }

        [Display(Name = "Название")]
        public virtual string Title { get; set; }

        [Display(Name = "Жанр")]
        public virtual string Janre { get; set; }

        [Display(Name = "Год выпуска")]
        public virtual string Year { get; set; }

        [Display(Name = "Полное описание")]
        public virtual string Text { get; set; }

        [Display(Name = "Титульная картинка")]
        public virtual string TitleImagePath { get; set; }

        [Display(Name = "SEO метатег Title")]
        public string MetaTitle { get; set; }

        [Display(Name = "SEO метатег Description")]
        public string MetaDescription { get; set; }

        [Display(Name = "SEO метатег Keywords")]
        public string MetaKeywords { get; set; }

        [DataType(DataType.Time)]
        public DateTime DateAdded { get; set; }
        protected EntityBase() => DateAdded = DateTime.UtcNow;
    }
}
