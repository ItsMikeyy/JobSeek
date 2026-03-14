using JobSeek.Data;

namespace JobSeek.Web.Models.DTO
{
    public class ListingDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Country Country { get; set; }
        public Company Company { get; set; }
        public State? State { get; set; }
        public string? StateName { get; set; }
        public decimal? Salary { get; set; }
        public decimal? SalaryMin { get; set; }
        public decimal? SalaryMax { get; set; }
        public string City { get; set; }
    }
}
