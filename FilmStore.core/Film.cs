using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmStore.core
{
    public class Film
    {
        public Film()
        {

        }

        public Film(string title, DateTime released, int stock, Enum genre)
        {
            
        }

        public long id { get; set; }
        public string Title { get; set; }
        public DateTime Released { get; set; }
        public int Stock { get; set; }
        public Enum Genre { get; set; }
    }
}
