using JobSeek.Data;

namespace JobSeek.Web.Models
{
    public class UserDTO
    {
        public UserDTO(UserAccount user)
        {
            FirstName = user.FirstName;
            LastName = user.LastName;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
