namespace TrainingManagementSystem.ViewModels.IdentityViewModels
{
    public class ChangePassword
    {
        [Required(ErrorMessage = "Email is Required.")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is Required.")]
        [StringLength(40, MinimumLength = 8, ErrorMessage = "The {0} must be at {2} And at max {1} character long.")]
        [DataType(DataType.Password)]
        [Compare("ConfirmNewPassword", ErrorMessage = "Password does not match.")]
        [Display(Name = "New Password")]

        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Confirm Password is Required.")]
        [DataType(DataType.Password)]
        [Display(Name = "confirm New Password")]
        public string ConfirmNewPassword { get; set; }
    }
}
