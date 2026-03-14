using JobSeek.Data;
using System.ComponentModel.DataAnnotations;

namespace JobSeek.Web.Areas.Companies.Models
{
    public class JobListingModel : IValidatableObject
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int CountryID { get; set; }
        public int? StateID { get; set; }
        public string? StateName { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public WorkArrangement WorkArrangement { get; set; }
        public decimal? Salary { get; set; }
        public decimal? SalaryMin { get; set; }
        public decimal? SalaryMax { get; set; }
        public SalaryType SalaryType { get; set; }
        [Required]
        public JobType JobType { get; set; }
        [Required]
        public DateTime PostedAt { get; set; }
        public DateTime? ExpiresAt { get; set; }
        [Required]
        public bool IsPublic { get; set; }
        public bool IsActive { get; set; }
        public int CompanyID { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            //Salary
            bool hasSalary = Salary.HasValue;
            bool hasMin = SalaryMin.HasValue;
            bool hasMax = SalaryMax.HasValue;
            bool hasRange = hasMin || hasMax;

            if (hasSalary && hasRange)
                yield return new ValidationResult(
                    "Salary cannot be combined with a salary range.",
                    [string.Empty]); // <-- targets model level, not a field

            // If using range, both must be provided
            if (hasRange)
            {
                if (!hasMin)
                    yield return new ValidationResult(
                        "Minimum salary is required when specifying a range.",
                        [nameof(SalaryMin)]);

                if (!hasMax)
                    yield return new ValidationResult(
                        "Maximum salary is required when specifying a range.",
                        [nameof(SalaryMax)]);

                // Min <= Max (only check if both are present)
                if (hasMin && hasMax && SalaryMin > SalaryMax)
                    yield return new ValidationResult(
                        "Minimum salary must be less than or equal to maximum salary.",
                        [nameof(SalaryMin), nameof(SalaryMax)]);
            }
        }
    }


}
