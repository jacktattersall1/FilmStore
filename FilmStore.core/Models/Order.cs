using FilmStore.core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmStore.core.Models
{
    class Order : IOrder
    {
        public List<Film> Films { get; set; }

        public DateTime OrderDate { get; set; }

        public int OrderId { get; set; }

        public string UserName { get; set; }

        public bool AddFilm(Film film)
        {
            throw new NotImplementedException();
        }

        public bool RemoveFilm(Film film)
        {
            throw new NotImplementedException();
        }
    }
}
