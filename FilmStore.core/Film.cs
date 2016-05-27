using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmStore.core
{
    public class Film
    {
        private int stock;

        public Film()
        {

        }

        public Film(string title, DateTime released, int stock, Enum genre)
        {
            Title = title;
            Released = released;
            Stock = stock;
            Genre = genre;
        }

        public long Id { get; set; }
        public string Title { get; set; }
        public DateTime Released { get; set; }
        public int Stock {
            get { return stock; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("Stock can't be negative");
                stock = value;
            }
        }
        public Enum Genre { get; set; }

        public override bool Equals(object obj)
        {
            return true;
        }

        public override int GetHashCode()
        {
            return 0;
        }
    }
}
