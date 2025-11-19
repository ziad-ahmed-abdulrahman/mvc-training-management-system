using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TrainingManagementSystem.ViewModels.DepartmentViewModels
{
    public class DepartmentWithDetails
    {
        [Display(Name = "Department Id")]
        public int Id { get; set; }

        [Display(Name = "Department Name")]
        public string Name { get; set; }

        [Display(Name = "Manager Name")]
        public string ManagerName { get; set; }

        [Display(Name = "Courses")]
        public List<DepartmentCourseViewModel> Courses { get; set; } = new();

        [Display(Name = "Instructors")]
        public List<DepartmentInstructorViewModel> Instructors { get; set; } = new();

        [Display(Name = "Trainees")]
        public List<DepartmentTraineeViewModel> Trainees { get; set; } = new();
    }

    public class DepartmentTraineeViewModel
    {
        [Display(Name = "Trainee Id")]
        public int Id { get; set; }

        [Display(Name = "Trainee Name")]
        public string Name { get; set; }
    }

    public class DepartmentInstructorViewModel
    {
        [Display(Name = "Instructor Id")]
        public int Id { get; set; }

        [Display(Name = "Instructor Name")]
        public string Name { get; set; }
    }

    public class DepartmentCourseViewModel
    {
        [Display(Name = "Course Id")]
        public int Id { get; set; }

        [Display(Name = "Course Name")]
        public string Name { get; set; }
    }
}
