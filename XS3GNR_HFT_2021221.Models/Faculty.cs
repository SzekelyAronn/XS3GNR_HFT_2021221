using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XS3GNR_HFT_2021221.Models
{
    [Table("Faculties")]
    public class Faculty
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name;

        [Required]
        [MaxLength(20)]
        public string ShortName;

        [ForeignKey(nameof(University))]
        public int UniId { get; set; }

        [NotMapped]
        public virtual ICollection<Student> Students { get; set; }

        [NotMapped]
        public virtual University University { get;set; }

        public Faculty()
        {
            Students = new HashSet<Student>();
        }
    }
}
