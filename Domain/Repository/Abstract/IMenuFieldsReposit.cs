using System.Linq;
using MovieAspCore.Domain.Entities;

namespace MovieAspCore.Domain.Repository.Abstract
{
    public interface IMenuFieldsReposit
    {
        IQueryable<MenuField> GetAll();
        MenuField GetOne(int id);
        MenuField GetCodeWord(string codeword);
        void Delete(int id);
        void ChangeSave(MenuField entity);
    }
}
