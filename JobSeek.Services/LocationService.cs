using JobSeek.Data;

namespace JobSeek.Services
{
    public class LocationService
    {
        private readonly JobSeekDBContext _dbContext;
        public LocationService(JobSeekDBContext context) 
        {
            _dbContext = context;
        }

        public List<State> GetStates()
        {
            return _dbContext.States.ToList();
        }

        public List<Country> GetCountries()
        {
            return _dbContext.Countries.ToList();
        }
    }
}
