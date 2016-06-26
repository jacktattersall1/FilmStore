using FilmStore.core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        public Film(string title, DateTime released, int stock, Genre genre)
        {
            Title = title;
            Released = released;
            Stock = stock;
            Genre = genre;
        }

        [Key]
        public long Id { get; set; }
        public string Title { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Column(TypeName = "datetime2")]
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
        public Genre Genre { get; set; }

        public override bool Equals(object obj)
        {
            return Id == (obj as Film).Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public virtual List<Order> Orders { get; set; }
    }
}
