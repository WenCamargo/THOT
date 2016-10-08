using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace THOT.Models
{
    public class Subject
    {
        public int SubjectId { get; set; }
        public int AreaId { get; set; }
        public string Name { get; set; }
        public Area Area { get; set; }
        public List<Unit> Units { get; set; }

    }
}