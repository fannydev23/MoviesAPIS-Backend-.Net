using APIMovies.Models;
using MoviesAPIS.Data;

namespace MoviesAPIS.Repositories
{
    public class GenderRepository
    {
        public ApplicationDbContext Context { get; set; }

        public GenderRepository(ApplicationDbContext ctx)
        {
            Context = ctx;
        }

        public IEnumerable<Genders> GetAll()
        {
            return Context.Set<Genders>();
        }

        public Genders Get(int id)
        {
            return Context.Find<Genders>(id);
        }
    }
}
