﻿using FilmStore.core;
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

        [TestMethod]
        public void InsertReturnsGeneratedId()
        {
            //Arrange
            CollectionFilmRepository sut = new CollectionFilmRepository();    // sut = system under test
            Film film1 = new Film("Jurassic Park", new DateTime(1984, 1, 20), 5, Genre.Science_Fiction);
            Film film2 = new Film("Matrix", new DateTime(1984, 1, 20), 5, Genre.Science_Fiction);

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
            Film film1 = new Film("Jurassic Park", new DateTime(1984, 1, 20), 5, Genre.Science_Fiction);
            Film film2 = new Film("Matrix", new DateTime(1984, 1, 20), 5, Genre.Science_Fiction);

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
            ICollection<Film> films = new List<Film>();
            CollectionFilmRepository sut = new CollectionFilmRepository(films);    // sut = system under test
            Film film1 = new Film("Jurassic Park", new DateTime(1984, 1, 20), 5, Genre.Science_Fiction);
            Film film2 = new Film("Matrix", new DateTime(1984, 1, 20), 5, Genre.Science_Fiction);
            sut.Insert(film1);
            sut.Insert(film2);

            //Act
            bool deleted = sut.Delete(film1);

            //Assert
            Assert.IsTrue(films.First().Title == "Matrix");
        }

        [TestMethod]
        public void SelectByIdReturnsCorrectFilm()
        {
            //Arrange
            ICollection<Film> films = new List<Film>();
            CollectionFilmRepository sut = new CollectionFilmRepository(films);    // sut = system under test
            Film film1 = new Film("Jurassic Park", new DateTime(1984, 1, 20), 5, Genre.Science_Fiction);
            Film film2 = new Film("Matrix", new DateTime(1984, 1, 20), 5, Genre.Science_Fiction);
            film1.Id = 1;
            film2.Id = 2;
            films.Add(film1);
            films.Add(film2);

            //Act
            Film filmSelected = sut.SelectById(2L);

            //Assert
            Assert.AreEqual(filmSelected, film2);
        }

        [TestMethod]
        public void SelectAllReturnsAllFilms()
        {
            //Arrange
            ICollection<Film> films = new List<Film>();
            CollectionFilmRepository sut = new CollectionFilmRepository(films);    // sut = system under test
            Film film1 = new Film("Jurassic Park", new DateTime(1984, 1, 20), 5, Genre.Science_Fiction);
            Film film2 = new Film("Matrix", new DateTime(1984, 1, 20), 5, Genre.Science_Fiction);
            films.Add(film1);
            films.Add(film2);

            //Act
            ICollection<Film> returnedFilms = sut.SelectAll();

            //Assert
            Assert.AreEqual(2, returnedFilms.Count);
        }
    }
}
