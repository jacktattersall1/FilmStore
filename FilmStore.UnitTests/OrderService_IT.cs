using FilmStore.core;
using FilmStore.core.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmStore.UnitTests
{
    [TestClass]
    public class OrderService_IT
    {
        //create mock objects
        private Mock<IFilmRepository> filmRepository = new Mock<IFilmRepository>();
        private Mock<IOrder> order = new Mock<IOrder>();
        private Mock<IOrderRepository> orderRepository = new Mock<IOrderRepository>();
        private OrderService orderService;
        Film film1 = new Film() { Id = 1, Title = "The Matrix", Stock = 5 };
        Film film2 = new Film() { Id = 2, Title = "Intensity", Stock = 5 };
        Film film3 = new Film() { Id = 3, Title = "Jurassic Park", Stock = 0 };
        private List<Film> films;

        [TestInitialize]
        public void BeforeEachTest()
        {
            //arrange - pass the mock instances into the system under tests constructor
            orderService = new OrderService(filmRepository.Object, orderRepository.Object, order.Object);
            films = new List<Film>();
            films.Add(film1);
            films.Add(film2);
            films.Add(film3);

            //inform the IFilmRepository mock how to respond to its SelectById method
            //being called with 1 or 2 as its argument
            filmRepository.Setup(fr => fr.SelectById(1L)).Returns(film1);
            filmRepository.Setup(fr => fr.SelectById(2L)).Returns(film2);

            //inform IOrder mock what to return when its Films property is called
            order.Setup(o => o.Films).Returns(films);
        }

        [TestMethod]
        public void AddFilmToOrderTest()
        {
            //Act
            orderService.AddFilmToOrder(1L);
            orderService.AddFilmToOrder(2L);

            //Assert
            order.Verify(o => o.AddFilm(It.Is<Film>(f => f.Id == 1)));
            order.Verify(o => o.AddFilm(It.Is<Film>(f => f.Id == 2)));
        }

        [TestMethod]
        public void RemoveFilmFromOrderTest()
        {
            //Act
            orderService.RemoveFilmFromOrder(2L);

            //Assert
            order.Verify(o => o.RemoveFilm(It.Is<Film>(f => f.Id == 2)));
        }

        [TestMethod]
        public void GetAllFilmsInOrderTest()
        {
            //Arrange
            //order.Setup(o => o.Films).Returns(films);

            //Act
            List<Film> filmsInOrder = orderService.GetAllFilmsInOrder();

            //Assert
            Assert.AreEqual(3, filmsInOrder.Count);
        }

        [TestMethod]
        public void SaveOrderTest()
        {
            //Arrange
            //order.Setup(o => o.Films).Returns(films);
            order.SetupProperty(o => o.UserName);

            //Act
            orderService.SaveOrder("Fred");

            //Assert
            Assert.AreEqual(4, film1.Stock);
            Assert.AreEqual(4, film2.Stock);
            Assert.AreEqual(0, film3.Stock);

            Assert.AreEqual(2, orderService.GetAllFilmsInOrder().Count);

            orderRepository.Verify(or => or.Save(order.Object));

            Assert.AreEqual("Fred", order.Object.UserName);
        }
    }
}
