using APIMovies.Models;
using Microsoft.AspNetCore.Mvc;
using MoviesAPIS.Data;
using MoviesAPIS.Models.DTO_s;
using MoviesAPIS.Repositories;

namespace MoviesAPIS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenderController : Controller
    {
        Repository<Genders> genreRepository;

        public ApplicationDbContext Context { get; set; }

        public GenderController(ApplicationDbContext ctx)
        {
            Context= ctx;
            genreRepository = new (Context);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var gendersList = genreRepository.Get().Select(x => new GendersDTO
            {
                idGender = x.idGender,
                gender = x.gender,
            }).OrderBy(x => x.gender).ToList();
            return Ok(gendersList);

        }
        //public IActionResult Get()
        //{
        //    GenderRepository repository = new GenderRepository(Context);
        //    return Ok(repository.GetAll());
        //}
    }
}
