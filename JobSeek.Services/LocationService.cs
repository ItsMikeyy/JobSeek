using JobSeek.Data;
using Microsoft.EntityFrameworkCore;

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
        public async Task<List<State>> GetStates()
        {
            return await _jobSeekDBContext.States.ToListAsync();
        }

        public async Task<List<State>> GetStatesByCountryID(int countryID)
        {
            return await _jobSeekDBContext.States.Where(s => s.CountryID == countryID).ToListAsync();
        }

        public async Task<State?> GetStateByStateID(int? stateID)
        {
            if (stateID == null) return null;

            return await _jobSeekDBContext.States.FirstOrDefaultAsync(s => s.StateID == stateID);
        }

        public async Task<bool> IsValidState(int countryID, int? stateID, string? stateName)
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
                var states = await GetStatesByCountryID(countryID);
                return states.Select(s => s.StateID == stateID).Any();
            }
        }

        #endregion

        #region Country
        public async Task<List<Country>> GetCountries()
        {
            return await _jobSeekDBContext.Countries.ToListAsync();
        }

        public async Task<Country?> GetCountryByID(int countryID) 
        {
            return await _jobSeekDBContext.Countries.FirstOrDefaultAsync(c => c.CountryID == countryID);
        }

        #endregion
    }
}
