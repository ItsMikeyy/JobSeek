using JobSeek.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

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

        public UserAccount? GetUserByEmail(string? email)
        {
            if (email == null) return null;

            return _dbContext.Users
                .Include(u => u.Company)
                .ThenInclude(c => c.Users)
                .FirstOrDefault(u => u.Email == email);
        }

        public bool UserEmailExists(string email)
        {
            return _dbContext.Users.Any(u => u.NormalizedEmail == email.ToUpper());
        }


       
    }
}
