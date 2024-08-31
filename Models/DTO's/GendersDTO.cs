using APIMovies.Models;
using System.ComponentModel.DataAnnotations;

namespace MoviesAPIS.Models.DTO_s
{
    public class GendersDTO
    {
        public int idGender { get; set; }
        public required string gender { get; set; }
    }
}
