namespace TrainingManagementSystem.ViewModels.TraineeViewModels
{
    public class CreateTraineeFormViewModel
    {

        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        [RegularExpression("^[A-Za-z ]+$", ErrorMessage = "Name must contain letters only")]
        [Display(Name = "Full Name")]
        public string Name { get; set; }

        [Display(Name = "Address")]
        [Required]
        public string Address { get; set; }

        [Range(1, 5, ErrorMessage = "The Grade is required.\r\n")]
        [Display(Name = "Grade")]
        [Required]
        public int Grade { get; set; } // 1, 2 ,3 ,4 ,5 => Grade = Academic Year (1 → First Year, 2 → Second Year, etc.)


        [Display(Name = "Department")]
        [Required]
        [Range(1, 10000, ErrorMessage = "The Department is required.\r\n")]
        public int SelectedDepartment { get; set; }
        public IEnumerable<SelectListItem> Departments { get; set; } = Enumerable.Empty<SelectListItem>();

        public List<int> SelectedCourses { get; set; } = new List<int>();
        public IEnumerable<SelectListItem> Courses { get; set; } = Enumerable.Empty<SelectListItem>();

    }
}
