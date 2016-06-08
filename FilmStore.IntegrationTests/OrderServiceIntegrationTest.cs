using FilmStore.core;
using FilmStore.core.Interfaces;
using FilmStore.core.Models;
using FilmStore.core.Repos;
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
    [TestClass]
    public class OrderServiceIntegrationTest
    {
        [ClassInitialize]
        public static void RunOnceForAllTests(TestContext context)
        {
            using(SqlConnection connection = new SqlConnection(new Settings().sqlConnection))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand(sqlBatch))
                {
                    cmd.Connection = connection;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        [TestMethod]
        public void IT_SaveOrder()
        {
            //Arrange
            IOrderService orderService = new OrderService(new EfFilmRepository(), new EFOrderRepository(), new Order());
            IFilmRepository filmRepository = new EfFilmRepository();

            //act
            orderService.AddFilmToOrder(1);
            orderService.SaveOrder("Ben");
            long film1StockLevelAfterCallingSaveOrder = filmRepository.SelectById(1).Stock;
 
            //Assert
            Assert.AreEqual(9, film1StockLevelAfterCallingSaveOrder);
        }

        private static string sqlBatch =
            "delete from Films;" +
            "dbcc checkident ('Films', reseed, 0);" +
            "insert into Films (title, released, stock, genre) values ('The Shawshank Redemption','1994-01-01',10, 1) ;" +
            "insert into Films (title, released, stock, genre) values ('The Godfather','1972-01-01',0, 1) ;" +
            "insert into Films (title, released, stock, genre) values ('The Godfather: Part II','1974-01-01',10, 1) ;" +
            "insert into Films (title, released, stock, genre) values ('Pulp Fiction','1994-01-01',10, 1) ;" +
            "insert into Films (title, released, stock, genre) values ('The Good, the Bad and the Ugly','1966-01-01',10, 1) ;";
    }
}
