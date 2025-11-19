namespace TrainingManagementSystem.Services.InstructorServices
{
    public interface IInstructorServices
    {
        IEnumerable<Instructor> GetAll();
        Instructor GetById(int id);
        void Add(Instructor instructor);
        void Update(Instructor instructor);
        void DeleteById(int id);
        public Instructor GetByIdWithDetails(int id);
    }
}
