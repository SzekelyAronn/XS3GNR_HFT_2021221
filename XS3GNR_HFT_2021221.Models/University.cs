using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XS3GNR_HFT_2021221.Models
{
        [Table("Universities")]
        public class University
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Id { get; set; }

            [MaxLength(20)]
            [Required]
            public string Name { get; set; }

            [MaxLength(10)]
            [Required]
            public string ShortName { get; set; }

            [NotMapped]
            public virtual ICollection<Faculty> Faculties { get; set; }

            public University()
            {
                Faculties = new HashSet<Faculty>();
            }

        }
}
