using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XS3GNR_HFT_2021221.Models
{
    [Table("students")]
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(6)]
        public string NeptunId { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [ForeignKey(nameof(Models.Faculty))]
        public int FacultyId { get; set; }

        [NotMapped]
        public virtual Faculty Faculty { get; set; }
    }
}
