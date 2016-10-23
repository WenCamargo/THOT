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
        public int UnitId { get; set; }
        [Required]
        [StringLength(50)]
        public string Number { get; set; }
        [Required]
        [StringLength(250)]
        public string Name { get; set; }
        [Required]
        public string Content { get; set; }
        public Unit Unit { get; set; }

    }
}