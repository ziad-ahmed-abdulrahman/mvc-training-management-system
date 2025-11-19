using System.Runtime.InteropServices;


namespace TrainingManagementSystem.Services.DepartmentServices
{
    public interface IDepartmentServices
    {
        IEnumerable<Department> GetAll();
        Department GetById(int id);
        void Add(Department Department);
        void Update(Department Department);
        void DeleteById(int id);

        public Department GetByIdWithDetails(int id);
      

    }
}
