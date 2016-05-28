using System;
using System.Collections.Generic;

namespace FilmStore.core
{
    public class CollectionFilmRepository : IFilmRepository
    {
        private ICollection<Film> films = new HashSet<Film>();
        private long id;

        public CollectionFilmRepository()
        {

        }

        public CollectionFilmRepository(ICollection<Film> films)
        {
            this.films = films;
        }

        public bool Delete(Film film)
        {
            return films.Remove(film);
        }

        public long Insert(Film film)
        {
            films.Add(film);
            id++;
            film.Id = id;
            return id;
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