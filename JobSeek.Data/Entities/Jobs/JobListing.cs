using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobSeek.Data
{
    [Table("JobListings")]

    public class JobListing
    {
        [Key]
        public int JobID { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }

        public string Location { get; set; }
        public bool IsRemote { get; set; }

        public decimal? SalaryMin { get; set; }
        public decimal? SalaryMax { get; set; }
        public SalaryType SalaryType { get; set; } 

        public JobType JobType { get; set; } 

        public DateTime PostedAt { get; set; }
        public DateTime? ExpiresAt { get; set; }

        public bool IsActive { get; set; }

        // Foreign key
        public int CompanyID { get; set; }
        public Company Employer { get; set; }

        public ICollection<JobApplication> Applications { get; set; }
    }

    public enum JobType 
    {
        FullTime,
        PartTime,
        Contract,
        Seasonal,
        Internship,
        Other
    }

    public enum SalaryType
    {
        Salary,
        Hourly,
        Contract,
    }

}
