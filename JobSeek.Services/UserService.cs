using JobSeek.Data;

namespace JobSeek.Services
{
    public class UserService
    {
        private readonly JobSeekDBContext _dbContext;
        public UserService(JobSeekDBContext jobSeekDBContext) 
        { 
            _dbContext = jobSeekDBContext;
        }

        public bool UserEmailExists(string email)
        {
            return _dbContext.Users.Any(u => u.NormalizedEmail == email.ToUpper());
        }
    }
}
