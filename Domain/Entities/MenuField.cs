using System.ComponentModel.DataAnnotations;

namespace MovieAspCore.Domain.Entities
{
    public class MenuField : EntityBase
    {
        
        public string CodeWord { get; set; }

        [Required]
        [Display(Name = "Название страницы (заголовок)")]
        public override string Title { get; set; }

        [Display(Name = "Cодержание страницы")]
        public override string Text { get; set; } = "Содержание заполняется администратором";
    }
}
