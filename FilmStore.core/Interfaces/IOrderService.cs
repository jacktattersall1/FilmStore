using System.Collections.Generic;

namespace FilmStore.core
{
    public interface IOrderService
    {
        void AddFilmToOrder(long id);
        List<Film> GetAllFilmsInOrder();
        void RemoveFilmFromOrder(long id);
        void SaveOrder(string userName);
    }
}