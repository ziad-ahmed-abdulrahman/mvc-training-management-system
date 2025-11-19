using TrainingManagementSystem.Models;

namespace TrainingManagementSystem.Services.DepartmentServices
{
    public class DepartmentServices : IDepartmentServices
    {
        private readonly IRepository<Department> _repo;
        private readonly IInstructorServices _instructorServices;
        private readonly ICourseServices _courseServices;
        private readonly ITraineeServices _traineeServices;



        public DepartmentServices(IRepository<Department> repo
            , ITraineeServices traineeServices
            , ICourseServices courseServices = null
            , IInstructorServices instructorServices = null)
        {
            _repo = repo;
            _traineeServices = traineeServices;
            _courseServices = courseServices;
            _instructorServices = instructorServices;
        }
        public void Add(Department department)
        {
            bool exists = _repo.GetAll()
               .Any(d => d.Name.ToLower() == department.Name.ToLower());

            if (!exists) 
            {
                _repo.Add(department);
                _repo.Save();
            }
           
        }

        public void DeleteById(int id)
        {
            Department department = _repo.GetById(id);
            if (department == null)
            {
                throw new Exception($"Department with Id = {id} was not found.");
            }
            _repo.Delete(department);
            _repo.Save();
        }

        public IEnumerable<Department> GetAll()
        {
            return _repo.GetAll();
        }

        public Department GetById(int id)
        {
            Department department = _repo.GetById(id);
            if (department == null) {
                throw new Exception($"Department with Id = {id} was not found.");
            }
            return department;

        }

        public void Update(Department department)
        {
            Department existing = _repo.GetById(department.Id);
            if (existing == null) 
            {
                throw new Exception($"Department with Id = {department.Id} was not found.");
            }
        

            existing.Name = department.Name;
            existing.ManagerName = department.ManagerName;

            _repo.Update(existing);
            _repo.Save();
           
        }
        public Department GetByIdWithDetails(int id) {

            DbSet<Department> set = _repo.Set();
         
           


            Department department = set.Include(d => d.Courses).Include(d => d.Instructors).Include(d => d.Trainees)
            .FirstOrDefault(d => d.Id == id);
          return department;

            
        }



    }
}
