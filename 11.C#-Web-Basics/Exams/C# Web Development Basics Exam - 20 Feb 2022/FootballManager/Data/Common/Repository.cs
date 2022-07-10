using Microsoft.EntityFrameworkCore;

namespace FootballManager.Data.Common
{
    public class Repository : IRepository
    {
        private readonly FootballManagerDbContext db;

        public Repository(FootballManagerDbContext db)
        {
            this.db = db;
        }

        public void Add<T>(T entity) where T : class
        {
            DbSet<T>().Add(entity);
        }

        public IQueryable<T> All<T>() where T : class
        {
            return DbSet<T>().AsQueryable();
        }

        public int SaveChanges()
        {
            return db.SaveChanges();
        }

        private DbSet<T> DbSet<T>() where T : class
        {
            return db.Set<T>();
        }
    }
}