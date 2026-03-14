using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobSeek.Data
{
    [Table("Companies")]
    public class Company
    {
        [Key]
        public int CompanyID { get; set; }

        public string CompanyName { get; set; }
        public string Website { get; set; }
        public string Description { get; set; }

        public ICollection<JobListing> JobListings { get; set; } = new List<JobListing>();
        public ICollection<UserAccount> Users { get; set; } = new List<UserAccount>();
    }
}
