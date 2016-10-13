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
        public int TopicId { get; set; }
        public int UnitId { get; set; }
        [StringLength(50)]
        public string Number { get; set; }
        [StringLength(250)]
        public string Name { get; set; }
        public string Content { get; set; }
        public Unit Unit { get; set; }

    }
}