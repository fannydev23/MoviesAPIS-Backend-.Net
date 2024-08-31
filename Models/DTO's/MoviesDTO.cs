using APIMovies.Models;
using System.ComponentModel.DataAnnotations;

namespace MoviesAPIS.Models.DTO_s
{
    public class MoviesDTO
    {
        public int idMovie { get; set; }
        public required string title { get; set; }

        public int? releaseYear { get; set; }
        public string? description { get; set; }

        public string? imageUrl { get; set; }

    }
}
