using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FilmStore.core;

namespace FilmStore.UnitTests
{
    [TestClass]
    public class FilmTest
    {
        [TestMethod]
        public void ConstructorShouldSetProperties()
        {
            //Arrange
            //Act
            Film film = new Film("Jurassic Park", new DateTime(1984, 1, 20), 5, Genre.Science_Fiction);

            //Assert
            Assert.AreEqual(film.Title, "Jurassic Park");
            Assert.AreEqual(film.Released, new DateTime(1984, 1, 20));
            Assert.AreEqual(film.Stock, 5);
            Assert.AreEqual(film.Genre, Genre.Science_Fiction);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ConstructorShouldThrowExceptionIfStockNegaative()
        {
            //Arrange
            //Act
            Film film = new Film("Jurassic Park", new DateTime(1984, 1, 20), -5, Genre.Science_Fiction);

        }

        [TestMethod]
        public void FilmsWithSameIdShouldBeEqualAndShouldHaveEqualHashCodes()
        {
            //Arrange
            Film film1 = new Film("Jurassic Park", new DateTime(1984, 1, 20), 5, Genre.Science_Fiction);
            Film film2 = new Film("Jurassic Park", new DateTime(1984, 1, 20), 5, Genre.Science_Fiction);

            //Assert
            Assert.AreEqual(film1, film2);
            Assert.AreEqual(film1.GetHashCode(), film2.GetHashCode());
        }
    }
}
