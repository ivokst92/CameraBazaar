namespace CameraBazaar.Services.BusinessModels
{
    using System.ComponentModel.DataAnnotations;

    public class UserDTO
    {
        public string Id { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email:")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password:")]
        public string Password { get; set; }
        [Required]
        [StringLength(12, MinimumLength = 10)]
        [RegularExpression(@"\+\d{10,12}", ErrorMessage = "Phone must start with '+' sign and contain 10 and 12 symbols.")]

        public string Phone { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Current Password:")]
        public string CurrentPassword { get; set; }
    }
}
