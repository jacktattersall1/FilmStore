using FilmStore.core.Properties;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmStore.core
{
    public class EfFilmRepository : IFilmRepository
    {
        public bool Delete(Film film)
        {
            using (FilmStoreContext context = new FilmStoreContext())
            {
                context.Entry(film).State = EntityState.Deleted;
                int i = context.SaveChanges();
                return i == 1 ? true : false;
            }
        }

        public long Insert(Film film)
        {
            using(FilmStoreContext context = new FilmStoreContext())
            {
                context.Entry(film).State = EntityState.Added;
                context.SaveChanges();
                return film.Id;
            }
        }

        public ICollection<Film> SearchByTitle(string title)
        {
            using(FilmStoreContext context = new FilmStoreContext())
            {
                return context.Films.Where(x => x.Title.Contains(title)).ToList();
            }
        }

        public ICollection<Film> SelectAll()
        {
            using(FilmStoreContext context = new FilmStoreContext())
            {
                return context.Films.ToList();
            }
        }

        public Film SelectById(long id)
        {
            using (FilmStoreContext context = new FilmStoreContext())
            {
                return context.Films.FirstOrDefault(x => x.Id == id);
            }
        }

        public Film SelectByTitle(string title)
        {
            using (FilmStoreContext context = new FilmStoreContext())
            {
                return context.Films.FirstOrDefault(x => x.Title == title);
            }
        }

        public bool Update(Film film)
        {
            using (FilmStoreContext context = new FilmStoreContext())
            {
                context.Entry(film).State = EntityState.Modified;
                int i = context.SaveChanges();
                return i == 1 ? true : false;
            }
        }
    }
}
