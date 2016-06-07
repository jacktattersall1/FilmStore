using System;
using FilmStore.core.Interfaces;

namespace FilmStore.core
{
    public class OrderService
    {
        private IFilmRepository object1;
        private IOrderRepository object2;
        private IOrder object3;

        public OrderService(IFilmRepository object1, IOrderRepository object2, IOrder object3)
        {
            this.object1 = object1;
            this.object2 = object2;
            this.object3 = object3;
        }

        public void AddFilmToOrder(long id)
        {
            object3.AddFilm(object1.SelectById(id));
        }
    }
}