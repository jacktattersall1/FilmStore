using FilmStore.core;
using FilmStore.IntegrationTests.Properties;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmStore.IntegrationTests
{
    class EfFilmRepository_IT
    {
        [ClassInitialize]
        public static void RunOnceForAllTests(TestContext context)
        {
            string connectionString = new Settings().sqlConnection;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = sqlBatch;
                cmd.ExecuteNonQuery();
            }
        }

        [TestMethod]
        public void IT_DbFilmRepository()
        {
            IFilmRepository sut = new EfFilmRepository();
            Assert.AreEqual(5, sut.SelectAll().Count(), "assertion 1");
            Assert.AreEqual(4, sut.SearchByTitle("the").Count()), "assertion 2");
            Film film1 = new Film("Aliens", new DateTime(1984, 1, 20), 5, Genre.Science_Fiction);
            Film film2 = new Film("The Matrix", new DateTime(1999, 5, 18), 2, Genre.Science_Fiction);
            //act
            long id1 = sut.Insert(film1);
            long id2 = sut.Insert(film2);

            Assert.AreEqual(film1, sut.SelectById(id1), "assertion 3");
            Assert.AreEqual(film2, sut.SelectById(id2), "assertion 4");

            film1 = sut.SelectById(id1);
            film1.Stock = 0;
            sut.Update(film1);
            Assert.AreEqual(0, sut.SelectById(id1).Stock, "assertion 5");

            sut.Delete(film2);
            Assert.IsNull(sut.SelectById(id2), "assertion 6");
        }

        private static string sqlBatch =
            "delete from film;" +
            "dbcc checkident ('Film', reseed, 0);" +
            "insert into Film (title, released, stock, genre) values ('The Shawshank Redemption','1994-01-01',10, 1) ;" +
            "insert into Film (title, released, stock, genre) values ('The Godfather','1972-01-01',0, 1) ;" +
            "insert into Film (title, released, stock, genre) values ('The Godfather: Part II','1974-01-01',10, 1) ;" +
            "insert into Film (title, released, stock, genre) values ('Pulp Fiction','1994-01-01',10, 1) ;" +
            "insert into Film (title, released, stock, genre) values ('The Good, the Bad and the Ugly','1966-01-01',10, 1) ;";
        }
}

