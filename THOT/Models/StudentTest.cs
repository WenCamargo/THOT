using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace THOT.Models
{
    public class StudentTest
    {
        public int StudentTestId { get; set; }
        public string UserId { get; set; }
        public int TestId { get; set; }
        public float Grade { get; set; }
        public DateTime CreationDate { get; set; }
        public Test Test { get; set; }
    }
}