using JobSeek.Data;
using Microsoft.EntityFrameworkCore;

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

        public async Task<List<JobListing>> GetJobListings(int amount=20)
        {
            return await _jobSeekDBContext.JobListings
                .Include(l => l.Country)
                .Include(l => l.State)
                .Include(l => l.Company)
                .OrderBy(l => l.PostedAt).Take(amount).ToListAsync();
        }
    }
}
