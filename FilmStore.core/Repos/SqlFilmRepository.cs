using FilmStore.core.Properties;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace FilmStore.core
{
    public class SqlFilmRepository : IFilmRepository
    {
        private string connectionString = new Settings().connectionString;

        public bool Delete(Film film)
        {
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                string queryString = "delete from film where " 
            }
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