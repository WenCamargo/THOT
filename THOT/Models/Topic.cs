using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace THOT.Models
{
    [Table("Topic")]
    public class Topic
    {
        [Display(Name = "Tema")]
        public int TopicId { get; set; }
        [Display(Name = "Unidad")]
        public int UnitId { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Tema")]
        public string Number { get; set; }
        [Required]
        [StringLength(250)]
        [Display(Name = "Nombre")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Contenido")]
        public string Content { get; set; }
        public Unit Unit { get; set; }

    }
}