using System;
using FilmStore.core.Interfaces;
using System.Collections.Generic;

namespace FilmStore.core
{
    public class OrderService
    {
        private IFilmRepository filmRepository;
        private IOrderRepository orderRepository;
        private IOrder order;

        public OrderService(IFilmRepository filmRepository, IOrderRepository orderRepository, IOrder order)
        {
            this.filmRepository = filmRepository;
            this.orderRepository = orderRepository;
            this.order = order;
        }

        public void AddFilmToOrder(long id)
        {
            order.AddFilm(filmRepository.SelectById(id));
        }

        public void RemoveFilmFromOrder(long id)
        {
            order.RemoveFilm(filmRepository.SelectById(id));
        }

        public List<Film> GetAllFilmsInOrder()
        {
            throw new NotImplementedException();
        }
    }
}