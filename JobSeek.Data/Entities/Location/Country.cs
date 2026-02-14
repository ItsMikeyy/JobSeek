using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobSeek.Data
{
    [Table("Countries")]
    public class Country
    {
        [Key]
        public int CountryID { get;set; }
        public string Name { get; set; }
        public string Currency { get; set; }
        public string CurrencySymbol { get; set; }
        public List<State> States { get; set; }
    }
}
