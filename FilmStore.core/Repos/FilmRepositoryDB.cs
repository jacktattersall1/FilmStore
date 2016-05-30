using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmStore.core
{
    class FilmRepositoryDB : IFilmRepository
    {
        public bool Delete(Film film)
        {
            throw new NotImplementedException();
        }

        public long Insert(Film film)
        {
            throw new NotImplementedException();
        }

        public ICollection<Film> SearchByTitle(string title)
        {
            throw new NotImplementedException();
        }

        public ICollection<Film> SelectAll()
        {
            throw new NotImplementedException();
        }

        public Film SelectById(long id)
        {
            throw new NotImplementedException();
        }

        public Film SelectByTitle(string title)
        {
            throw new NotImplementedException();
        }

        public bool Update(Film film)
        {
            throw new NotImplementedException();
        }
    }
}
