using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace THOT.Models
{
    public class Topic
    {
        public int TopicId { get; set; }
        public int UnitId { get; set; }
        public string Number { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public Unit Unit { get; set; }
    }
}