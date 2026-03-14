using JobSeek.Data;

namespace JobSeek.Services
{
    public class ListingService
    {
        private readonly JobSeekDBContext _jobSeekDBContext;
        public ListingService(JobSeekDBContext jobSeekDBContext)
        {
            _jobSeekDBContext = jobSeekDBContext;
        }

        public async Task<bool> AddJobListing(JobListing listing, Company company)
        {
            try
            {
                _jobSeekDBContext.JobListings.Add(listing);
                company.JobListings.Add(listing);
                await _jobSeekDBContext.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
