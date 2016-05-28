using System;
using System.Collections.Generic;

namespace FilmStore.core
{
    public class CollectionFilmRepository : IFilmRepository
    {
        private ICollection<Film> films;

        public CollectionFilmRepository(ICollection<Film> films)
        {
            this.films = films;
        }

        public bool Delete(Film film)
        {
            throw new NotImplementedException();
        }

        public long Insert(Film film)
        {
            films.Add(film);
            return film.Id;
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