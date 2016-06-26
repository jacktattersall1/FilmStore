using System.ComponentModel.DataAnnotations;

namespace FilmStore.core
{
    public enum Genre
    {
        [Display(Name = "Science Fiction")]
        Science_Fiction,
        [Display(Name = "Romance")]
        Romance

    }
}