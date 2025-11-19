namespace TrainingManagementSystem.Services.InstructorServices
{
    public class InstructorServices : IInstructorServices
    {
        private readonly IRepository<Instructor> _repo;

        public InstructorServices(IRepository<Instructor> repo)
        {
            _repo = repo;
        }
        public void Add(Instructor instructor)
        {
           
            _repo.Add(instructor);
            _repo.Save();
        }

        public void DeleteById(int id)
        {
            Instructor instructor = _repo.GetById(id);
            if (instructor == null)
            {
                throw new Exception($"Instructor with Id = {id} was not found.");
            }
            _repo.Delete(instructor);
            _repo.Save();
        }

        public IEnumerable<Instructor> GetAll()
        {
            return _repo.GetAll();
        }

        public Instructor GetById(int id)
        {
            Instructor instructor = _repo.GetById(id);
            if (instructor == null)
            {
                throw new Exception($"Instructor with Id = {id} was not found.");
            }
            return instructor;

        }

        public void Update(Instructor instructor)
        {
            Instructor existing = _repo.GetById(instructor.Id);
            if (existing == null)
            {
                throw new Exception($"Instructor with Id = {instructor.Id} was not found.");
            }

            existing.Id = instructor.Id;
            existing.Name = instructor.Name;
            existing.Address = instructor.Address;
            existing.Salary = instructor.Salary;
            existing.CourseId = instructor.CourseId;
            existing.DeptId = instructor.DeptId;


            _repo.Update(existing);
            _repo.Save();

        }

        public Instructor GetByIdWithDetails(int id)
        {
            var set = _repo.Set();
            return set.Include(t => t.Department).Include(t => t.Course).FirstOrDefault(c => c.Id == id);
        }
    }
}
