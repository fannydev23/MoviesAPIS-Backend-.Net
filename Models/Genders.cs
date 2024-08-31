using System.ComponentModel.DataAnnotations;

namespace APIMovies.Models
{
    public class Genders
    {
        [Key]
        public int idGender { get; set; }

        [Required]
        public required string gender { get; set; }

        public ICollection<Movie>? Movies { get; set; }
    }
}
