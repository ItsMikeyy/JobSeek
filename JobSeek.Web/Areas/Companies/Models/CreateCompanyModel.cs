using System.ComponentModel.DataAnnotations;

namespace JobSeek.Web.Areas.Companies.Models
{
    public class CreateCompanyModel
    {
        [Required]
        public string CompanyName { get; set; }

        [Url(ErrorMessage = "Please enter a valid website URL.")]
        public string Website { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
