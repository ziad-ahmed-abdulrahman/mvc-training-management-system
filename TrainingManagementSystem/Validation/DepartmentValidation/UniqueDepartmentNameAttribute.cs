

namespace TrainingManagementSystem.Validation.DepartmentValidation
{
    public class UniqueDepartmentNameAttribute : ValidationAttribute
    {
        

       

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null) {
                return ValidationResult.Success;
            }
            var service = (IDepartmentServices)validationContext.GetService(typeof(IDepartmentServices));
            string name = value.ToString();    

            bool exists = service.GetAll().Any(x => x.Name == name);

            if (exists == true) {
            return new ValidationResult("This department name already exists.");    
            }

            return ValidationResult.Success;
        }
    }
}
