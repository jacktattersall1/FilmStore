using FilmStore.core.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmStore.core.Models
{
    public class Order : IOrder
    {
        public Order()
        {
            Films = new List<Film>();
        }

        public List<Film> Films { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime OrderDate { get; set; }

        public int OrderId { get; set; }

        public string UserName { get; set; }

        public bool AddFilm(Film film)
        {
            if (Films.Contains(film))
                return false;
            Films.Add(film);
            return true;
        }

        public bool RemoveFilm(Film film)
        {
            return Films.Remove(film);
        }
    }
}
