using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace THOT.Models
{
    [Table("Score")]
    public class Score
    {
        public int ScoreId { get; set; }
        public int TestId { get; set; }
        public double Grade { get; set; }
        public Test Test { get; set; }

    }
}