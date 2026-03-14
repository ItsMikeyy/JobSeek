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
        public int CountryID{ get; set; }
        public int? StateID { get; set; }
        public string? StateName { get; set; }
        public string City { get; set; }
        public WorkArrangement WorkArrangement { get; set; }
        public decimal? Salary { get; set; }
        public decimal? SalaryMin { get; set; }
        public decimal? SalaryMax { get; set; }
        public SalaryType SalaryType { get; set; } 
        public JobType JobType { get; set; } 
        public DateTime PostedAt { get; set; }
        public DateTime? ExpiresAt { get; set; }
        public bool IsPublic { get; set; }
        public bool IsActive { get; set; }
        public int CompanyID { get; set; }
        public Country Country { get; set; }
        public State? State { get; set; }
        public Company Company { get; set; }

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

    public enum WorkArrangement
    {
        InOffice,
        Hybrid,
        Remote
    }

}
