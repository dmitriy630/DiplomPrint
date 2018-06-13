using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiplomPrint.Model
{
    public class Electives
    {
        [Key]
        public int ElectivesID { get; set; }

        [Required]
        public string ElectivesName { get; set; }

        [Required]
        public int QuantityHours { get; set; }

        [InverseProperty("Electives")]
        public virtual Student elective { get; set; }

        [Required]
        public string Rating { get; set; }
    }
}
