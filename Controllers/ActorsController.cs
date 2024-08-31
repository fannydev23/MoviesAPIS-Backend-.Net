using APIMovies.Models;
using Microsoft.AspNetCore.Mvc;
using MoviesAPIS.Data;
using MoviesAPIS.Models.DTO_s;
using MoviesAPIS.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MoviesAPIS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorsController : ControllerBase
    {

        Repository<Actor> actorsRepository;
        public ApplicationDbContext Context { get; set; }

        public ActorsController(ApplicationDbContext ctx)
        {
            Context = ctx;
            actorsRepository = new(Context);
        }

        // GET: api/<ActorsController>
        [HttpGet]
        public IActionResult Get()
        {
            var actors = actorsRepository.Get().Select(x => new ActorsDTO
            {
                idActor = x.idActor,
                name = x.name,
                lastName = x.lastName,
                imageUrl = x.imageUrl,
            }).OrderBy(x => x.name).ToList();
            return Ok(actors);

        }

        // GET api/<ActorsController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<ActorsController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<ActorsController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<ActorsController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
