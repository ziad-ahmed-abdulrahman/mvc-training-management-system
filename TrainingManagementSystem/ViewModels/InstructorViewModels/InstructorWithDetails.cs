namespace TrainingManagementSystem.ViewModels.InstructorViewModels
{
    public class InstructorWithDetails
    {
        [Display(Name = "Instructor Id")]
        public int Id { get; set; }

        [Display(Name = "Instructor Name")]
        public string Name { get; set; }

        [Display(Name = "Instructor Salary")]
        public int Salary { get; set; }

        [Display(Name = "Instructor Address")]
        public string Address { get; set; }

        
        [Display(Name = "Course Id")]
        public int SelectedCourse { get; set; }

        [Display(Name = "Course Name")]
        public string courseName { get; set; }

        [Display(Name = "Department Id")]
        public int SelectedDepartment { get; set; }

        [Display(Name = "Department Name")]
        public string DepartmentName { get; set; }
    }
     
    }
