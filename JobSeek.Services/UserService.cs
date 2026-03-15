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

        public async Task<UserAccount?> GetUserByEmail(string? email)
        {
            if (email == null) return null;

            return await _dbContext.Users
                .Include(u => u.Company)
                    .ThenInclude(c => c.JobListings)
                        .ThenInclude(l => l.Country)
                .Include(u => u.Company)
                    .ThenInclude(c => c.JobListings)
                        .ThenInclude(l => l.State)
                .Include(u => u.Company)
                    .ThenInclude(c => c.Users)
                .FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<bool> UserEmailExists(string email)
        {
            return await _dbContext.Users.AnyAsync(u => u.NormalizedEmail == email.ToUpper());
        }


       
    }
}
