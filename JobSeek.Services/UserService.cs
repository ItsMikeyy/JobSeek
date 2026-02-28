using JobSeek.Data;
using Microsoft.AspNetCore.Identity;

namespace JobSeek.Services
{
    public class UserService
    {
        private readonly JobSeekDBContext _dbContext;
        private readonly UserManager<UserAccount> _userManager;

        public UserService(JobSeekDBContext jobSeekDBContext, UserManager<UserAccount> userManager) 
        { 
            _dbContext = jobSeekDBContext;
            _userManager = userManager;
        }

        public bool UserEmailExists(string email)
        {
            return _dbContext.Users.Any(u => u.NormalizedEmail == email.ToUpper());
        }

        public void AddUserCompany(Company company, UserAccount user)
        {
            user.Company = company;
            user.CompanyID = company.CompanyID;
            _dbContext.SaveChanges();

        }
       
    }
}
