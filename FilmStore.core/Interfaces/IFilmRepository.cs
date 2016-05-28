using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmStore.core
{
    interface IFilmRepository
    {
        long Insert(Film film);
        Film SelectById(long id);
        ICollection<Film> SelectAll();
        Film SelectByTitle(string title);
        ICollection<Film> SearchByTitle(string title);
        bool Update(Film film);
        bool Delete(Film film);
    }
}
