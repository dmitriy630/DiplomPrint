using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DiplomPrint.Model
{
    public class StateAttestation
    {
        [Key]
        public int StateAttestationID { get; set; }

        [InverseProperty("StateAtt")]
        public virtual Student stateAtt { get; set; }

        [Required]
        public string StateAttestationName { get; set; }

        [Required]
        public int QuantityWeeks { get; set; }

        [Required]
        public string Rating { get; set; }
    }
}
