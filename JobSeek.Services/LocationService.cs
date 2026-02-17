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

        public List<State> GetStatesByCountryID(int countryID)
        {
            return _dbContext.States.Where(s => s.CountryID == countryID).ToList();
        }

        public bool IsValidState(int countryID, int? stateID, string? stateName)
        {
            // If Canada or USA stateName should be null
            if ((countryID == 39 || countryID == 233) && !String.IsNullOrEmpty(stateName)) 
            {
                return false;
            }

            if (stateID == null && !String.IsNullOrEmpty(stateName))
            {
                return true;
            } 
            else
            {
                var states = GetStatesByCountryID(countryID);
                return states.Select(s => s.StateID == stateID).Any();

            }



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
