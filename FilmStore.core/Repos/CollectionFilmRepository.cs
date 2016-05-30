using FilmStore.core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FilmStore.core
{
    public class CollectionFilmRepository : IFilmRepository
    {
        private ICollection<Film> films = new HashSet<Film>();
        private long id;
        ISerializer serializer;

        public CollectionFilmRepository()
        {

        }

        public CollectionFilmRepository(ISerializer serializer)
        {
            this.serializer = serializer;
            films = serializer.Read();
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
            id++;
            film.Id = id;
            films.Add(film);
            if(serializer != null)
                serializer.Write(films);
            return id;
        }

        public ICollection<Film> SearchByTitle(string title)
        {
            return films.Where(x => x.Title.Contains(title)).ToList();
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