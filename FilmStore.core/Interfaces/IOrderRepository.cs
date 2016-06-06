using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmStore.core.Interfaces
{
    interface IOrderRepository
    {
        long Save(IOrder iOrder);
    }
}
