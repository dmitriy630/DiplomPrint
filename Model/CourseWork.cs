using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiplomPrint.Model
{
    public class CourseWork
    {
        [Key]
        public int CourseWorkID { get; set; }

        [InverseProperty("CourseWork")]
        public virtual Student course { get; set; }

        [Required]
        public string CourseWorkName { get; set; }

        [Required]
        public string Rating { get; set; }
    }
}
