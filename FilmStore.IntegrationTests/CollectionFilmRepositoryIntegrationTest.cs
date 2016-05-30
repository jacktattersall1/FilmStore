using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using FilmStore.core;
using Ninject;
using FilmStore.core.Interfaces;
using Ninject.Parameters;

namespace FilmStore.IntegrationTests
{
    [TestClass]
    public class CollectionFilmRepositoryIntegrationTest
    {
        [ClassInitialize]
        public static void RunOnceForAllTests(TestContext context)
        {
            string path = @"C:\Users\jackt\OneDrive\Documents\FilmStoreSeralizes\object.xml";
            File.Delete(path);
        }

        [TestMethod]
        public void CollectionFilmRepository_IT()
        {
            //Arrange
            var kernel = new StandardKernel(new DependencyInjection());
            ISerializer serializer = kernel.Get<ISerializer>();
            IFilmRepository sut = kernel.Get<IFilmRepository>(new ConstructorArgument("serializer", serializer));

            Film film1 = new Film("Aliens", new DateTime(1984, 1, 20), 5, Genre.Science_Fiction);
            Film film2 = new Film("Predator", new DateTime(1984, 1, 20), 5, Genre.Science_Fiction);

            //Act
            long id1 = sut.Insert(film1);
            long id2 = sut.Insert(film2);

            //Assert
            Assert.AreEqual(2, sut.SelectAll().Count, "Assertion 1");
            Assert.AreEqual(1, sut.SearchByTitle("Aliens").Count, "Assertion 2");
            Assert.AreEqual(film1, sut.SelectById(id1), "Assertion 3");
            Assert.AreEqual(film2, sut.SelectById(id2), "Assertion 4");

            film1.Stock = 0;
            sut.Update(film1);
            Assert.AreEqual(0, sut.SelectById(id1).Stock, "Assertion 5");

            sut.Delete(film2);
            Assert.IsNull(sut.SelectById(id2), "Assertion 6");
        }
    }
}
