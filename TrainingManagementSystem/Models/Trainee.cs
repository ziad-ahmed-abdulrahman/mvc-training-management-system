namespace TrainingManagementSystem.Models
{
    public class Trainee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public string Address { get; set; }

        public int Grade { get; set; } // 1, 2 ,3 ,4 ,5 => Grade = Academic Year (1 → First Year, 2 → Second Year, etc.)

        public int DeptId { get; set; }

        public virtual Department Department { get; set; }

        public virtual List<CrsReslt> CrsReslts { get; set; } = new List<CrsReslt>();
    }
}
