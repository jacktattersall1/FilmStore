using FilmStore.core;
using FilmStore.IntegrationTests.Properties;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace FilmStore.IntegrationTests
{
    [TestClass]
    public class SqlFilmRepositoryTest
    {
        [ClassInitialize]
        public static void RunOnceForAll(TestContext context)
        {
            string connectionString = new Settings().sqlConnection;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sqlBatch;
                cmd.ExecuteNonQuery();
            }
        }

        [TestMethod]
        public void SqlFilmRepository_IT()
        {
            IFilmRepository sut = new SqlFilmRepository();
            Assert.AreEqual(5, sut.SelectAll().Count, "Assertion 1 ");
            Assert.AreEqual(2, sut.SearchByTitle("The").Count, "Assertion 2");
            Assert.AreEqual("Damien", sut.SelectByTitle("Damien").Title, "Assertion 3");

            Film film1 = new Film("Jurassica", new DateTime(1986, 1, 20), 5, Genre.Science_Fiction);
            Film film2 = new Film("Comando", new DateTime(1986, 1, 20), 5, Genre.Science_Fiction);

            //Act
            long id1 = sut.Insert(film1);
            long id2 = sut.Insert(film2);

            Assert.AreEqual(film1.Title, sut.SelectById(id1).Title, "Assertion 4");
            Assert.AreEqual(film2.Title, sut.SelectById(id2).Title, "Assertion 5");

            film1 = sut.SelectById(id1);
            film1.Stock = 0;
            sut.Update(film1);
            Assert.AreEqual(0, sut.SelectById(id1).Stock, "Assertion 6");

            sut.Delete(sut.SelectById(id2));
            Assert.IsNull(sut.SelectById(id2), "Assertion 7");
        }

        private static string sqlBatch =
            "delete from film;" +
            "dbcc checkident ('Film', reseed, 0);" +
            "insert into Film (title, released, stock, genre) values ('The Shawshank Redemption', '1994-01-01', 10, 0);" +
            "insert into Film (title, released, stock, genre) values ('Aliens', '1994-01-01', 10, 0);" +
            "insert into Film (title, released, stock, genre) values ('The Predator', '1994-01-01', 10, 0);" +
            "insert into Film (title, released, stock, genre) values ('Jaws', '1994-01-01', 10, 0);" +
            "insert into Film (title, released, stock, genre) values ('Damien', '1994-01-01', 10, 0);";

    }
}
