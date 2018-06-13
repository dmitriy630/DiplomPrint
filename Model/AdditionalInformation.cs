using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiplomPrint.Model
{
    public class AdditionalInformation
    {
        [Key]
        public int InformationID { get; set; }

        [InverseProperty("addInfo")]
        public virtual Student addInfo { get; set; }

        [MaxLength(2000)]
        public string Information { get; set; }
    }
}
