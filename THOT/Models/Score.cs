using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace THOT.Models
{
    public class Score
    {
        public int ScoreId { get; set; }
        public int TestId { get; set; }
        public double Grade { get; set; }
    }
}