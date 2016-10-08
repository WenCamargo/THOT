using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace THOT.Models
{
    public class Unit
    {
        public int UnitId { get; set; }
        public int SubjectId { get; set; }
        public string Number { get; set; }
        public string Name { get; set; }
        public Subject Subject { get; set; }
        public List<Topic> Topics { get; set; }
    }
}