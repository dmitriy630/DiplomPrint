using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiplomPrint.Model
{
    public class Practice
    {
        [Key]
        public int PracticeID { get; set; }

        [Required]
        public string PracticeName { get; set; }

        [Required]
        public int QuantityWeeks { get; set; }

        [Required]
        public string Rating { get; set; }

        [InverseProperty("Practice")]
        public virtual Student practice { get; set; }
    }
}
