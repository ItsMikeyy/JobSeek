using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobSeek.Data
{
    [Table("Candidates")]

    public class Candidate
    {
        [Key]
        public int CandidateID { get; set; }
        public string UserID { get; set; }
        public UserAccount User { get; set; }
        public ICollection<CandidateDocument> Documents { get; set; }
        public ICollection<JobApplication> Applications { get; set; }
    }
}
