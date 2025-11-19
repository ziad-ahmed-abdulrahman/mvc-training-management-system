
using TrainingManagementSystem.Data;

namespace TrainingManagementSystem.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly DbSet<T> _dbSet;

        public Repository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            _dbSet = _applicationDbContext.Set<T>();
        }
        public void Add(T entity)
        {
            _dbSet.Add( entity );
        }

        public void Delete(T entity)
        {
            
                _dbSet.Remove(entity);
            
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.AsNoTracking().ToList(); 
        }

        public T GetById(int id)
        {
            T entity = _dbSet.Find(id);
            return entity;   
        }
        public void Update(T entity)
        {
            _dbSet.Update(entity);  
        }
        public void Save()
        {
           _applicationDbContext.SaveChanges();
        }

        public DbSet<T> Set() {
        return _dbSet;
        }

    }
}
