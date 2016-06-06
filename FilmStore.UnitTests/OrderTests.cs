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
            Film film2 = new Film("The Matrix", new DateTime(1999, 5, 18), 2, Genre.Science_Fiction) { Id = 2 };
            order.Films.Add(film1);
            order.Films.Add(film2);

            //Act
            bool removed = order.RemoveFilm(film1);

            //Assert
            CollectionAssert.DoesNotContain(order.Films, film1);
            Assert.IsTrue(removed);
        }
    }
}

