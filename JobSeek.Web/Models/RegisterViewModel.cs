using JobSeek.Data;

namespace JobSeek.Web.Models
{
    public class RegisterViewModel
    {
        public UserAccountFormModel UserAccountFormModel { get; set; }
        public List<Country> Countries { get; set; }
    }
}
