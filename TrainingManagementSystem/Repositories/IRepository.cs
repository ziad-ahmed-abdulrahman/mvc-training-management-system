namespace TrainingManagementSystem.Repositories
{
    public interface IRepository<T> where T : class
    {
        public IEnumerable<T> GetAll();
        T GetById(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Save(); 
        DbSet<T> Set();
    }
}
