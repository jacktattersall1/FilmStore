using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmStore.core.Interfaces
{
    public interface IOrder
    {
        List<Film> Films { get; set; }
        DateTime OrderDate { get; set; }
        int OrderId { get; set; }
        string UserName { get; set; }

        bool AddFilm(Film film);
        bool RemoveFilm(Film film);
    }
}
