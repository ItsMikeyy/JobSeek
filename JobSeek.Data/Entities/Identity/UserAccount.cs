using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobSeek.Data
{
    [Table("UserAccounts")]
    public class UserAccount : IdentityUser
    {
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CountryID { get; set; }
        public int StateID { get; set; }
        public string City { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string ZipCode { get; set; }
        public State State { get; set; }
        public Country Country { get; set; }

    }
}
