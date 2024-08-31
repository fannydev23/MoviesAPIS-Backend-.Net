using APIMovies.Models;
using MoviesAPIS.Data;

namespace MoviesAPIS.Repositories
{
    public class ActorRepository
    {
        public ApplicationDbContext Context { get; set; }

        public ActorRepository(ApplicationDbContext ctx)
        {
            Context = ctx;
        }

        public IEnumerable<Actor> GetAll()
        {
            return Context.Set<Actor>();
        }

        public Actor Get(int id)
        {
            return Context.Find<Actor>(id);
        }
    }
}
