namespace TrainingManagementSystem.ViewModels.InstructorViewModels
{
    public class EditInstructorFormViewModel
    {


        [Display(Name = "Id")]
        public int Id { get; set; }


        
        [Display(Name = "Full Name")]
        [MaxLength(50)]
        [Required]
        [RegularExpression("^[A-Za-z ]+$", ErrorMessage = "Name must contain letters only")]
        [Remote(action: "IsNameUnique", controller: "Instructor", AdditionalFields = "Id")]
        public string Name { get; set; }


        [MaxLength(5)]
        [Display(Name = "Salary")]
        [Required]
        [Range(7000, 25000, ErrorMessage = "Salary must be between 7000 and 25000.")]
        public int Salary { get; set; }


        [Display(Name = "Address")]
        [Required]
        public string Address { get; set; }


        [Display(Name = "Course")]
        [Required]
        public int SelectedCourse { get; set; }

        public IEnumerable<SelectListItem> Courses { get; set; } = Enumerable.Empty<SelectListItem>();


        [Display(Name = "Department")]
        [Required]
        public int SelectedDepartment { get; set; }
        public IEnumerable<SelectListItem> Departments { get; set; } = Enumerable.Empty<SelectListItem>();
    }
}
