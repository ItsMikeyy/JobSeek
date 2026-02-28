using JobSeek.Data;

namespace JobSeek.Services
{
    public class CompanyService
    {
        private readonly JobSeekDBContext _jobSeekDBContext;
        public CompanyService(JobSeekDBContext jobSeekDBContext) 
        {
            _jobSeekDBContext = jobSeekDBContext;
        }

        public Company GetCompanyByUserCompanyID(int userCompanyID)
        {
            Company? company = _jobSeekDBContext.Companies.FirstOrDefault(c => c.CompanyID == userCompanyID);
            return company;
        }      
    }
}
