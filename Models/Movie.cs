using System.ComponentModel.DataAnnotations;

namespace APIMovies.Models
{
    public class Movie
    {
        [Key]
        public int idMovie { get; set; }

        [Required]
        public required string title { get; set; }

        public int? releaseYear { get; set; }
        public string? description { get; set; }

        public string? imageUrl { get; set; }

        public required ICollection<Genders> Genders { get; set; }
        public required ICollection<Actor> Actors { get; set; }
    }
}
