using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobSeek.Data
{
    [Table("JobApplications")]
    public class JobApplication
    {
        [Key]
        public int ApplicationID { get; set; }

        public int JobListingID { get; set; }
        public JobListing JobListing { get; set; }

        public int UserID { get; set; }
        public UserAccount Candidate { get; set; }

        public int? ResumeID { get; set; }
        public UserDocument Resume { get; set; }

        public int? CoverLetterID { get; set; }
        public UserDocument CoverLetter { get; set; }

        public DateTime AppliedAt { get; set; }

        public ApplicationStatus Status { get; set; }
    }
    public enum ApplicationStatus
    {
        Submitted,        
        Review,      
        InterviewScheduled,
        Interviewed,
        OfferExtended,
        Accepted,
        Rejected,
        Withdrawn         
    }
}

