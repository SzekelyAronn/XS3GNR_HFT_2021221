using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XS3GNR_HFT_2021221.Models
{
    [Table("faculties")]
    public class Faculty
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(20)]
        public string ShortName { get; set; }

        [ForeignKey(nameof(University))]
        public int UniId { get; set; }

        [Required]
        public int LocationbyDistrict { get; set; }

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
