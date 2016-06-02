using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using FilmStore.UnitTests.Properties;
using FilmStore.core;

namespace FilmStore.UnitTests
{
    [TestClass]
    public class SqlFilmRepositoryUnitTests
    {
        [ClassInitialize]
        public static void RunOnceForAll(TestContext context)
        {
            string connectionString = new Settings().connectionString;
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
        public void InsertShouldAddFilmsToTable()
        {
            IFilmRepository sut = new SqlFilmRepository();
            Film film1 = new Film("Jurassica", new DateTime(1986, 1, 20), 5, Genre.Science_Fiction);
            Film film2 = new Film("Comando", new DateTime(1986, 1, 20), 5, Genre.Science_Fiction);

            //Act
            long id1 = sut.Insert(film1);
            long id2 = sut.Insert(film2);

            Assert.AreEqual(film1, sut.SelectById(id1), "Assertion 1");
            Assert.AreEqual(film2, sut.SelectById(id2), "Assertion 2");
        }

        private static string sqlBatch =
            "delete from film;" +
            "dbcc checkident ('Film', reseed, 0);" +
            "insert into Film (title, released, stock, genre) values ('The Shawshank Redemption', '1994-01-01', 10, 1);" +
            "insert into Film (title, released, stock, genre) values ('Aliens', '1994-01-01', 10, 1);" +
            "insert into Film (title, released, stock, genre) values ('The Predator', '1994-01-01', 10, 1);" +
            "insert into Film (title, released, stock, genre) values ('Jaws', '1994-01-01', 10, 1);" +
            "insert into Film (title, released, stock, genre) values ('Damien', '1994-01-01', 10, 1);";

    }
}
