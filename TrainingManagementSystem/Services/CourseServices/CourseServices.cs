using Microsoft.EntityFrameworkCore;

namespace TrainingManagementSystem.Services.CourseServices
{
    public class CourseServices : ICourseServices
    {
        private readonly IRepository<Course> _repo;

        public CourseServices(IRepository<Course> repo)
        {
            _repo = repo;
        }
        public void Add(Course course)
        {
            bool exists = _repo.GetAll()
                .Any(d => d.Name.ToLower() == course.Name.ToLower());
            if (!exists)
            {
                _repo.Add(course);
                _repo.Save();
            }
        }

        public void DeleteById(int id)
        {
            Course Course = _repo.GetById(id);
            if (Course == null)
            {
                throw new Exception($"Course with Id = {id} was not found.");
            }
            _repo.Delete(Course);
            _repo.Save();
        }

        public IEnumerable<Course> GetAll()
        {
            return _repo.GetAll();
        }

        public Course GetById(int id)
        {
            Course course = _repo.GetById(id);
            if (course == null)
            {
                throw new Exception($"Course with Id = {id} was not found.");
            }
            return course;

        }

        public void Update(Course course)
        {
            Course existing = _repo.GetById(course.Id);
            if (existing == null)
            {
                throw new Exception($"Course with Id = {course.Id} was not found.");
            }


            existing.Name = course.Name;
            existing.DeptId = course.DeptId;
            existing.Degree = course.Degree;
            existing.MinDegree = course.MinDegree;
            existing.Hours = course.Hours;

            _repo.Update(existing);
            _repo.Save();

        }

        public Course GetByIdWithDetails(int id)
        {
            var set =  _repo.Set();
            return set.Include(c => c.Department).Include(c => c.Instructors).FirstOrDefault( c => c.Id == id);
        }

    }
}
