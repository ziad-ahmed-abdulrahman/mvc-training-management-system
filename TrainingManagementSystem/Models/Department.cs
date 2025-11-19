namespace TrainingManagementSystem.Models
{
    public class Department
    {
        public int Id { get; set; }

        [MaxLength(30)]
        [Required]
        [RegularExpression("^[A-Za-z ]+$", ErrorMessage = "Name must contain letters only")]
        [UniqueDepartmentName]
        public String Name { get; set; }

        [Display(Name = "Manager Name")]
        [MaxLength(50)]
        [Required]
        [RegularExpression("^[A-za-z ]+$", ErrorMessage = "Name must contain letters only and spaces")]
        public String ManagerName { get; set; }

        public virtual List<Instructor> Instructors { get; set; } = new List<Instructor>();

        public virtual List<Course> Courses { get; set; } = new List<Course>();

        public virtual List<Trainee> Trainees { get; set; } = new List<Trainee>();
    }
}
