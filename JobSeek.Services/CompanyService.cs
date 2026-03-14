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

        public Company? GetCompanyByUserCompanyID(int? userCompanyID)
        {
            if (userCompanyID == null)
            {
                return null;
            }
            Company? company = _jobSeekDBContext.Companies.FirstOrDefault(c => c.CompanyID == userCompanyID);
            return company;
        }

        public void CreateCompany(Company company, UserAccount user)
        {
            _jobSeekDBContext.Companies.Add(company);
            _jobSeekDBContext.SaveChanges(); 

            user.Company = company;
            user.CompanyID = company.CompanyID;
            _jobSeekDBContext.SaveChanges();

        }
    }
}
