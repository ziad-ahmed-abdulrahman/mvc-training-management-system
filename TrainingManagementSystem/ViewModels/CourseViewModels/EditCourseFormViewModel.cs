

namespace TrainingManagementSystem.ViewModels.CourseViewModels
{
    public class EditCourseFormViewModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        [RegularExpression("^[A-Za-z ]+$", ErrorMessage = "Name must contain letters only")]
        [Remote(action: "IsNameUnique", controller: "Course", AdditionalFields = "Id")]
        public string Name { get; set; }

        [Required]
        public int Degree { get; set; }

        [Required]
        [Display(Name = "Minimum Degree")]
        public int MinDegree { get; set; }
        [Required]
        public int Hours { get; set; }

        [Required]
        [Display(Name = "Department")]
        public int SelectedDepartment { get; set; }
        public IEnumerable<SelectListItem> Departments { get; set; } = Enumerable.Empty<SelectListItem>();

        [Display(Name = "Instructors")]
        public List<int> SelectedInstructors { get; set; } = new List<int>();
        public IEnumerable<SelectListItem> Instructors { get; set; } = Enumerable.Empty<SelectListItem>();
    }
}
