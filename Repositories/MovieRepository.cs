using APIMovies.Models;
using Microsoft.EntityFrameworkCore;
using MoviesAPIS.Data;

namespace MoviesAPIS.Repositories
{
    public class MovieRepository
    {
        public ApplicationDbContext Context { get; set; }

        public MovieRepository(ApplicationDbContext ctx)
        {
            Context = ctx;
        }

        public async Task<IEnumerable<Movie>> GetAll()
        {
            //return Context.Set<Movie>();

            var movieList = await Context.Movies.Include(m => m.Actors).ToListAsync();

            return movieList;
        }

        public Movie Get(int id)
        {
            return Context.Find<Movie>(id);
        }
    }
}
