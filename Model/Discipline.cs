using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiplomPrint.Model
{
    public class Discipline
    {
        [Key]
        public int DisciplineID { get; set; }

        [Required]
        public string DisciplineName { get; set; }

        [Required]
        public int QuantityHours { get; set; }

        [InverseProperty("Discipline")]
        public virtual Student discipline { get; set; }

        [Required]
        public string Rating { get; set; }
    }
}
