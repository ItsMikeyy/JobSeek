using System.ComponentModel.DataAnnotations;

namespace JobSeek.Web.Models
{
    public class UserAccountFormModel : IValidatableObject
    {
        [Required(ErrorMessage = "First name is required")]
        [StringLength(50, MinimumLength = 2)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [StringLength(50, MinimumLength = 2)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        [StringLength(100)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Password must be at least 8 characters")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Country is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Please select a country")]
        public int CountryID { get; set; }

        public int? StateID { get; set; }
        public string? StateName { get; set; }

        [Required(ErrorMessage = "City is required")]
        public string City{ get; set; }

        [Required(ErrorMessage = "Date of birth is required")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Zip/Postal code is required")]
        [StringLength(10, ErrorMessage = "Invalid postal code length")]
        public string ZipCode { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            bool hasStateId = StateID.HasValue;
            bool hasStateName = !string.IsNullOrWhiteSpace(StateName);

            if (hasStateId == hasStateName)
            {
                yield return new ValidationResult(
                    "Provide either a state selection or enter a state name, but not both.",
                    new[] { nameof(StateID), nameof(StateName) }
                );
            }
        }
    }
}
