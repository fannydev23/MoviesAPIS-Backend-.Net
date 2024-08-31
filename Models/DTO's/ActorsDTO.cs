using APIMovies.Models;
using System.ComponentModel.DataAnnotations;

namespace MoviesAPIS.Models.DTO_s
{
    public class ActorsDTO
    {
        public int idActor { get; set; }
        public required string name { get; set; }
        public required string lastName { get; set; }

        public string? imageUrl { get; set; }

    }
}
