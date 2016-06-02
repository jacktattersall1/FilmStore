using FilmStore.core;
using FilmStore.core.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmStore.UnitTests
{
    [TestClass]
    public class OrderTests
    {
        [TestMethod]
        public void AddFilmShoulAddCorrectFilmToOrder()
        {
            //Arrange
            Order order = new Order();
            Film film1 = new Film("Jurassic Park", new DateTime(1984, 1, 20), 5, Genre.Science_Fiction) { Id = 1 };

            //Act
             bool added = order.AddFilm(film1);

            //Assert
            Assert.AreEqual(film1, order.Films.First());
            Assert.IsTrue(added);
        }

        [TestMethod]
        public void RemoveFilmShouldRemoveGivenFilm()
        {
            //Arrange
            Order order = new Order();
            Film film1 = new Film("Jurassic Park", new DateTime(1984, 1, 20), 5, Genre.Science_Fiction) { Id = 1 };
            order.Films.Add(film1);

            //Act
            bool removed = order.RemoveFilm(film1);

            //Assert
            Assert.IsNull(order.Films.First());
            Assert.IsTrue(removed);
        }
    }
}

