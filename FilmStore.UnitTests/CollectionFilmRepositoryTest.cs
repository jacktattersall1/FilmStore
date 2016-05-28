using FilmStore.core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmStore.UnitTests
{
    [TestClass]
    public class CollectionFilmRepositoryTest
    {
        [TestMethod]
        public void InsertAddsFilmToCollection()
        {
            //Arrange
            ICollection<Film> films = new List<Film>();
            CollectionFilmRepository sut = new CollectionFilmRepository(films);    // sut = system under test
            Film film = new Film("Jurassic Park", new DateTime(1984, 1, 20), 5, Genre.Science_Fiction);

            //act
            long id = sut.Insert(film);

            //Assert
            Assert.AreEqual(1, films.Count);

        }
    }
}
