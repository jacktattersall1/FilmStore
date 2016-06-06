using FilmStore.core.Interfaces;
using FilmStore.core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmStore.core.Repos
{
    class EFOrderRepository : IOrderRepository
    {
        public long Save(IOrder iOrder)
        {
            using(FilmStoreContext context = new FilmStoreContext())
            {
                context.Entry(iOrder).State = EntityState.Added;
                iOrder.Films.ForEach(film => context.Entry(film).State = EntityState.Modified);
                context.SaveChanges();
                return iOrder.OrderId;
            }
        }
    }
}
