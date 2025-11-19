using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using TrainingManagementSystem.Validation;

namespace TrainingManagementSystem.ViewModels.DepartmentViewModels
{
    public class CreateDepartmentFormViewModel
    {
        [Display(Name ="Id")]
        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        [RegularExpression("^[A-Za-z ]+$", ErrorMessage = "Name must contain letters only")]
        [Remote(action: "IsNameUnique", controller: "Department", AdditionalFields = "Id")]
        public string Name { get; set; }

        [Display(Name = "Manager Full Name")]
        [MaxLength(50)]
        [Required]
        [RegularExpression("^[A-za-z ]+$", ErrorMessage = "Name must contain letters only and spaces")]

        public string ManagerName { get; set; }
    }
}
