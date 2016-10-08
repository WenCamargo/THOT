using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace THOT.Models
{
    public class Area
    {
        public int AreaId { get; set; }
        public string Name { get; set; }
        public List<Subject> Subject { get; set; }

    }
}