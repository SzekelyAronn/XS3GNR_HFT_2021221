using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XS3GNR_HFT_2021221.Models
{
    [Table("Students")]
    public class Students
    {
        [Key]
        [MaxLength(6)]
        public string NeptunId { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        [ForeignKey(nameof(Faculties))]
        public int FacultyId { get; set; }

        [NotMapped]
        public virtual Faculties Faculty { get; set; }
    }
}
