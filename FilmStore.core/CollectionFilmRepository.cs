using System;
using System.Collections.Generic;
using System.Linq;

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
            return films;
        }

        public Film SelectById(long id)
        {
            return films.FirstOrDefault(x => x.Id == id);
        }

        public Film SelectByTitle(string title)
        {
            return films.FirstOrDefault(x => x.Title == title);
        }

        public bool Update(Film film)
        {
            bool removed = true;
            removed = films.Remove(film);
            films.Add(film);
            return removed;
        }
    }
}