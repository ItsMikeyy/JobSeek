using JobSeek.Data;
using Microsoft.EntityFrameworkCore;

namespace JobSeek.Services
{
    public class CompanyService
    {
        private readonly JobSeekDBContext _jobSeekDBContext;
        public CompanyService(JobSeekDBContext jobSeekDBContext) 
        {
            _jobSeekDBContext = jobSeekDBContext;
        }

        public async Task<Company?> GetCompanyByUserCompanyID(int? userCompanyID)
        {
            if (userCompanyID == null)
            {
                return null;
            }
            Company? company = await _jobSeekDBContext.Companies.FirstOrDefaultAsync(c => c.CompanyID == userCompanyID);
            return company;
        }

        public async Task<bool> CreateCompany(Company company, UserAccount user)
        {
            try
            {
                _jobSeekDBContext.Companies.Add(company);
                user.Company = company;
                user.CompanyID = company.CompanyID;

                await _jobSeekDBContext.SaveChangesAsync();


                return true;
            } catch (Exception ex)
            {
                return false;
            }


        }
    }
}
