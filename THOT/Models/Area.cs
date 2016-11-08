using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace THOT.Models
{
    [Table("Area")]
    public class Area
    {
        [Display(Name = "Rama")]
        public int AreaId { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Rama")]
        public string Name { get; set; }
        public List<Subject> Subject { get; set; }

    }
}