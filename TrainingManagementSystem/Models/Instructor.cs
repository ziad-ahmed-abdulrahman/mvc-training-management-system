using System.ComponentModel.DataAnnotations;

namespace TrainingManagementSystem.Models
{
    public class Instructor
    {

        public int Id { get; set; }

        [MaxLength(30, ErrorMessage = "Name must be less than 30 letter")]
        [MinLength(3, ErrorMessage = "Name must be greater than 3 letter")]
        [Required]

        public string Name { get; set; }
       
        [Range(7000, 100000)]
        [Required]
        public int Salary { get; set; }
        [Required]
        [RegularExpression(@"(Alex|Assiut)")]
        public string Address { get; set; }
        [Display(Name = "Department")]
        public int DeptId { get; set; }
        [Display(Name = "Course Id")]
        public int CourseId { get; set; }

        public virtual Department Department { get; set; }

        public virtual Course Course { get; set; }
    }
}
