using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;


namespace THOT.Models
{
    [Table("Unit")]
    public class Unit
    {
        [Display(Name = "Unidad")]
        public int UnitId { get; set; }
        public int SubjectId { get; set; }
        [Required]
        [StringLength(5)]
        public string Number { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        public Subject Subject { get; set; }
        public List<Topic> Topics { get; set; }
    }
}