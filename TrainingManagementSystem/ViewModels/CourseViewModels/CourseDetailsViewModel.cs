

namespace TrainingManagementSystem.ViewModels.CourseViewModels
{
    public class CourseDetailsViewModel
    {

      
        [Display(Name = "Course Id")]
        public int Id { get; set; }

        [Display(Name = "Course Name")]
        public string Name { get; set; }

        [Display(Name = "Course Degree")]
        public int Degree { get; set; }

       
        [Display(Name = "Minimum Degree")]
        public int MinDegree { get; set; }

        [Display(Name = "Course Hours")]
        public int Hours { get; set; }

       
        [Display(Name = "Department")]
        public int SelectedDepartment { get; set; }

       
        [Display(Name = "Department Name")]
        public string DepartmentName { get; set; }
        public List<InstructorInfoViewModel> Instructors { get; set; } = new();
    }

    public class InstructorInfoViewModel
    {
        [Display(Name = "Instructor Id")]
        public int Id { get; set; }
        [Display(Name = "Instructor Name")]
        public string Name { get; set; }
    }


}

