using APIMovies.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesAPIS.Data;
using MoviesAPIS.Models.DTO_s;
using MoviesAPIS.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MoviesAPIS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {

        public ApplicationDbContext Context { get; set; }

        Repository<Movie> movieRepository;

        public MoviesController(ApplicationDbContext ctx)
        {
            Context = ctx;
            movieRepository = new(Context);
        }
        // GET: api/<MoviesController>
        [HttpGet]
        public IActionResult Get()
        {
            var moviesList = movieRepository.Get().Select(x => new MoviesDTO
            {
                idMovie = x.idMovie,
                title = x.title,
                imageUrl = x.imageUrl,
            }).OrderBy(x => x.imageUrl).ToList();
            return Ok(moviesList);

        }

        [HttpGet("ByGenre/{idGenre}")]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMoviesByGenre(int idGenre)
        {
            var movies = await Context.Movies
                .Where(m => m.Genders.Any(g => g.idGender==idGenre))
                .Include(m => m.Genders)
                .ToListAsync();

            if (movies == null || !movies.Any())
            {
                return NotFound($"No movies found for genre: {idGenre}");
            }

            return Ok(movies);
        }


        // GET: api/Movies/Search?query=Inception
        [HttpGet("Search")]
        public async Task<ActionResult<IEnumerable<Movie>>> SearchMovies(string query)
        {
            if (string.IsNullOrEmpty(query))
            {
                return BadRequest("Search query must be provided.");
            }

            var movies = await Context.Movies
                .Where(m =>
                    m.title.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                    m.Genders.Any(g => g.gender.Contains(query, StringComparison.OrdinalIgnoreCase)) ||
                    m.Actors.Any(a =>
                        (a.name + " " + a.lastName).Contains(query, StringComparison.OrdinalIgnoreCase)))
                .ToListAsync();


            //var movies = Context.Movies
            //    .Include(m => m.Genders)
            //    .Include(m => m.Actors)
            //    .Include(m => m.Actors)
            //    .AsEnumerable().ToList();  // Cambiar a memoria para evaluación cliente
            //.Where(m =>
            //    m.title.Contains(query, StringComparison.OrdinalIgnoreCase) ||
            //    m.Genders.Any(g => g.gender.Contains(query, StringComparison.OrdinalIgnoreCase)) ||
            //    m.Actors.Any(a =>
            //        (a.name + " " + a.lastName).Contains(query, StringComparison.OrdinalIgnoreCase)))
            //.ToList();

            if (movies == null || !movies.Any())
            {
                return NotFound($"No movies found matching the search query: {query}.");
            }

            return Ok(movies);
        }

        //// GET api/<MoviesController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<MoviesController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<MoviesController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<MoviesController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
