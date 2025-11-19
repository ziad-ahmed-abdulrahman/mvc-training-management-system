namespace TrainingManagementSystem.ViewModels.IdentityViewModels
{
    public class VerifyEmailViewmodel
    {
        [Required(ErrorMessage = "Email is Required")]
        [EmailAddress]
        public string Email { get; set; }
    }
}
