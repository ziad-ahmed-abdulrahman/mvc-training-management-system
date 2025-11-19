using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;


namespace TrainingManagementSystem.Services.CourseServices
{
    public interface ICourseServices
    {
        IEnumerable<Course> GetAll();
        Course GetById(int id);
        void Add(Course Course);
        void Update(Course Course);
        void DeleteById(int id);
        public Course GetByIdWithDetails(int id);
       



    }
}
