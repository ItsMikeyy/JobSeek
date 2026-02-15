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

        #region State
        public List<State> GetStates()
        {
            return _dbContext.States.ToList();
        }

        public List<State> GetStatesByCountryID(int CountryID)
        {
            return _dbContext.States.Where(s => s.CountryID == CountryID).ToList();
        }

        #endregion




        #region Country
        public List<Country> GetCountries()
        {
            return _dbContext.Countries.ToList();
        }

        #endregion
    }
}
