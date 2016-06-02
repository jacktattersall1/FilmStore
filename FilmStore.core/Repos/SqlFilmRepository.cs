using FilmStore.core.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace FilmStore.core
{
    public class SqlFilmRepository : IFilmRepository
    {
        private string connectionString = new Settings().connectionString;

        public bool Delete(Film film)
        {
            SqlOperation delete = new SqlOperation
            {
                query = "delete from film where id = @filmId ",
                parameters = new string[] { film.Id.ToString() }
            };

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using(SqlCommand cmd = new SqlCommand(delete.query, connection))
                {
                    cmd.Parameters.Add(new SqlParameter("filmId", delete.parameters[0]));
                    
                    return cmd.ExecuteNonQuery() == 1;
                } 
            }
        }

        public long Insert(Film film)
        {
            SqlOperation insert = new SqlOperation
            {
                query = "insert into Film (title, released, stock, genre) values (@title, @released, @stock, @genre) SELECT SCOPE_IDENTITY();"
            };

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand(insert.query, connection))
                {
                    cmd.Parameters.AddWithValue("title", film.Title);
                    cmd.Parameters.AddWithValue("released", film.Released);
                    cmd.Parameters.AddWithValue("stock", film.Stock);
                    cmd.Parameters.AddWithValue("genre", film.Genre);
                    int id = Convert.ToInt32(cmd.ExecuteScalar());
                    return id;
                }
                
            }
        }

        public ICollection<Film> SearchByTitle(string title)
        {
            SqlOperation selectAll = new SqlOperation
            {
                query = "select * from film WHERE title LIKE '%' + @title + '%';",
                parameters = new string[] {title}
            };

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand(selectAll.query, connection))
                {
                    cmd.Parameters.AddWithValue("title", title);

                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        ICollection<Film> films = new List<Film>();

                        while (rdr.Read())
                        {
                            films.Add(new Film((string)rdr["title"], (DateTime)rdr["released"], (int)rdr["stock"], (Genre)rdr["genre"]));
                        }
                        return films;
                    }
                }
            }
        }

        public ICollection<Film> SelectAll()
        {
            SqlOperation selectAll = new SqlOperation
            {
                query = "select * from film",
            };

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand(selectAll.query, connection))
                {
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        ICollection<Film> films = new List<Film>();

                        while(rdr.Read())
                        {
                            films.Add(new Film((string)rdr["title"], (DateTime)rdr["released"], (int)rdr["stock"], (Genre)rdr["genre"]) { Id = (long)rdr["id"] });
                        }
                        
                        return films;
                    }
                }
            }
        }

        public Film SelectById(long id)
        {
            SqlOperation selectById = new SqlOperation
            {
                query = "select * from film where id = @id",
                parameters = new string[] { id.ToString() }
            };

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand(selectById.query, connection))
                {
                    cmd.Parameters.AddWithValue("id", selectById.parameters[0]);
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        Film film1 = null;

                        if (rdr.Read())
                        {
                            film1 = new Film((string)rdr["title"], (DateTime)rdr["released"], (int)rdr["stock"], (Genre)rdr["genre"]);
                            film1.Id = (long)rdr["id"];
                        }
                        return film1;
                    }
                }
            }
        }

        public Film SelectByTitle(string title)
        {
            SqlOperation selectById = new SqlOperation
            {
                query = "select * from film where title = @title",
                parameters = new string[] { title }
            };

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand(selectById.query, connection))
                {
                    cmd.Parameters.AddWithValue("title", selectById.parameters[0]);
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        Film film1 = null;

                        if (rdr.Read())
                        {
                            film1 = new Film((string)rdr["title"], (DateTime)rdr["released"], (int)rdr["stock"], (Genre)rdr["genre"]);
                            film1.Id = (long)rdr["id"];
                        }
                        return film1;
                    }
                }
            }
        }

        public bool Update(Film film)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "update Film set title = @title, released = @released, stock = @stock, genre = @genre where id = @id";
                    cmd.Connection = connection as SqlConnection;
                    cmd.Parameters.AddWithValue("id", film.Id);
                    cmd.Parameters.AddWithValue("title", film.Title);
                    cmd.Parameters.AddWithValue("released", film.Released);
                    cmd.Parameters.AddWithValue("stock", film.Stock);
                    cmd.Parameters.AddWithValue("genre", film.Genre);
                    return cmd.ExecuteNonQuery() == 1;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

    }
}