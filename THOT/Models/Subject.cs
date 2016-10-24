using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;


namespace THOT.Models
{
    [Table("Subject")]
    public class Subject
    {
        public int SubjectId { get; set; }
        public int AreaId { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Materia")]
        public string Name { get; set; }
        public Area Area { get; set; }
        public List<Unit> Units { get; set; }

    }
}