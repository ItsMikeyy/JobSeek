using JobSeek.Data;
using JobSeek.Web.Areas.Companies.Models;

namespace JobSeek.Web.Areas.Companies.ViewModels
{
    public class JobListingViewModel
    {        
        public JobListingModel JobListingModel { get; set; }
        public List<Country> Countries { get; set; }
        public Dictionary<int, string> JobType { get; set; }
        public Dictionary<int, string> SalaryType { get; set; }
        public Dictionary<int, string> WorkArrangement { get; set; }
    }
}
