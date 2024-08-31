using System.ComponentModel.DataAnnotations;

namespace APIMovies.Models
{
    public class Actor
    {
        [Key]
        public int idActor { get; set; }
        [Required]
        public required string name { get; set; }
        [Required]
        public required string lastName { get; set; }

        public string? imageUrl { get; set; }

        public ICollection<Movie>? Movies { get; set; }

    }
}
