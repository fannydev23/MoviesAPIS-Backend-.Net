using Microsoft.EntityFrameworkCore;
using MoviesAPIS.Data;

namespace MoviesAPIS.Repositories
{
    public class Repository<T> where T : class
    {
        private readonly ApplicationDbContext context;

        public Repository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public DbSet<T> Get()
        {
            return context.Set<T>();
        }
        public T? Get(object id)
        {
            return context.Find<T>(id);
        }
        public void Insert(T entity)
        {
            context.Add(entity);
            context.SaveChanges();
        }
        public void Update(T entity)
        {
            context.Update(entity);
            context.SaveChanges();
        }
        public void Delete(T entity)
        {
            context.Remove(entity);
            context.SaveChanges();
        }
    }
}
