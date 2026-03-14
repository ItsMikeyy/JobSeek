using JobSeek.Data;

namespace JobSeek.Services
{
    public class LocationService
    {
        private readonly JobSeekDBContext _jobSeekDBContext;
        public LocationService(JobSeekDBContext jobSeekDBContext) 
        {
            _jobSeekDBContext = jobSeekDBContext;
        }

        #region State
        public List<State> GetStates()
        {
            return _jobSeekDBContext.States.ToList();
        }

        public List<State> GetStatesByCountryID(int countryID)
        {
            return _jobSeekDBContext.States.Where(s => s.CountryID == countryID).ToList();
        }

        public State? GetStateByStateID(int? stateID)
        {
            if (stateID == null) return null;

            return _jobSeekDBContext.States.FirstOrDefault(s => s.StateID == stateID);
        }

        public bool IsValidState(int countryID, int? stateID, string? stateName)
        {
            // If Canada or USA stateName should be null
            if ((countryID == 39 || countryID == 233) && !String.IsNullOrEmpty(stateName)) 
            {
                return false;
            }

            // Free text state
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
            return _jobSeekDBContext.Countries.ToList();
        }

        public Country? GetCountryByID(int countryID) 
        {
            return _jobSeekDBContext.Countries.FirstOrDefault(c => c.CountryID == countryID);
        }

        #endregion
    }
}
