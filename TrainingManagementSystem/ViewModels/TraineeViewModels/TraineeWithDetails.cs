namespace TrainingManagementSystem.ViewModels.TraineeViewModels
{
    public class TraineeWithDetails
    {

        public int Id { get; set; }

        [Display(Name = "Full Name")]
        public string Name { get; set; }

        [Display(Name = "Address")]
        public string Address { get; set; }

        [Display(Name = "Academic Year")]
        public int Grade { get; set; } // 1 → First Year, 2 → Second Year, etc.

        [Display(Name = "Department Id")]
        public int SelectedDepartment { get; set; }

        [Display(Name = "Department Name")]
        public string DepartmentName { get; set; }

        [Display(Name = "Courses Results")]
        public List<CrsResultsViewModel> CrsResults { get; set; } = new();
    }

    public class CrsResultsViewModel
    {
        [Display(Name = "Course Id")]
        public int CourseId { get; set; }

        [Display(Name = "Course Name")]
        public string CourseName { get; set; }

        [Display(Name = "Course Degree")]
        public int CourseDegree { get; set; }

        [Display(Name = "Minimum Degree")]
        public int CourseMinDegree { get; set; }

        [Display(Name = "Trainee Degree")]
        public int? TraineeDegree { get; set; }

        [Display(Name = "Passed?")]
        public bool? IsPassed { get; set; }

        [Display(Name = "Date Completed")]
        public DateTime? DateCompleted { get; set; }
    }

}
