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
        private static Film film1 = new Film("Jurassic Park", new DateTime(1984, 1, 20), 5, Genre.Science_Fiction) { Id = 1 };
        private static Film film2 = new Film("Matrix", new DateTime(1984, 1, 20), 5, Genre.Science_Fiction) { Id = 2 };
        private static List<Film> films = new List<Film>();

        [ClassInitialize]
        public static void RunOnceForAllTests(TestContext context)
        {
            films.Add(film1);
            films.Add(film2);
        }

        #region Unit Tests

        [TestMethod]
        public void InsertAddsFilmToCollection()
        {
            //Arrange
            CollectionFilmRepository sut = new CollectionFilmRepository(films);    // sut = system under test

            //act
            long id = sut.Insert(film1);

            //Assert
            Assert.AreEqual(3, films.Count);
        }

        [TestMethod]
        public void InsertReturnsGeneratedId()
        {
            //Arrange
            CollectionFilmRepository sut = new CollectionFilmRepository();    // sut = system under test
            
            //act
            long id1 = sut.Insert(film1);
            long id2 = sut.Insert(film2);

            //Assert
            Assert.IsTrue(id1 < id2);
        }

        [TestMethod]
        public void InsertSetsIdOfFilm()
        {
            //Arrange
            CollectionFilmRepository sut = new CollectionFilmRepository();    // sut = system under test
            
            //Act
            long id1 = sut.Insert(film1);
            long id2 = sut.Insert(film2);

            //Assert
            Assert.IsTrue(film1.Id == id1);
            Assert.IsTrue(film2.Id == id2);
            Assert.IsTrue(id1 > 0);
        }

        [TestMethod]
        public void DeleteRemovesFilmFromCollection()
        {
            //Arrange
            CollectionFilmRepository sut = new CollectionFilmRepository(films);    // sut = system under test
            
            //Act
            bool deleted = sut.Delete(film1);

            //Assert
            Assert.IsTrue(films.First().Title == "Matrix");
        }

        [TestMethod]
        public void SelectByIdReturnsCorrectFilm()
        {
            //Arrange
            CollectionFilmRepository sut = new CollectionFilmRepository(films);    // sut = system under test
           
            //Act
            Film filmSelected = sut.SelectById(2L);

            //Assert
            Assert.AreEqual(filmSelected, film2);
        }

        [TestMethod]
        public void SelectAllReturnsAllFilms()
        {
            //Arrange
            CollectionFilmRepository sut = new CollectionFilmRepository(films);    // sut = system under test
           
            //Act
            ICollection<Film> returnedFilms = sut.SelectAll();

            //Assert
            Assert.AreEqual(2, returnedFilms.Count);
        }

        [TestMethod]
        public void SelectByTitleReturnsCorrectFilm()
        {
            //Arrange
            CollectionFilmRepository sut = new CollectionFilmRepository(films);
            
            //Act
            Film returnedFilm = sut.SelectByTitle("Matrix");

            //Assert
            Assert.AreEqual(film2, returnedFilm);
        }

        [TestMethod]
        public void UpdateCorrectlyUpdatesFilmInCollection()
        {
            //Arrange
            CollectionFilmRepository sut = new CollectionFilmRepository(films);
           
            //Act
            Film film3 = new Film("Jurassic Park", new DateTime(1984, 1, 20), 3, Genre.Science_Fiction);
            film3.Id = 3;
            bool isUpdated = sut.Update(film3);

            //Assert
            Assert.AreEqual(film2.Stock, films.First().Stock);
        }

        [TestMethod]
        public void SearchByTitleReturnsCorrectFilms()
        {
            //Arrange
            CollectionFilmRepository sut = new CollectionFilmRepository(films);    // sut = system under test
            
            //Act
            Film film3 = new Film("Jurassic Park", new DateTime(1984, 1, 20), 3, Genre.Science_Fiction);
            film2.Id = 1;
            ICollection<Film> returnedFilms = sut.SearchByTitle("Jurassic");

            //Assert
            Assert.IsTrue(returnedFilms.Count == 2);
        }
        #endregion


    }
}
