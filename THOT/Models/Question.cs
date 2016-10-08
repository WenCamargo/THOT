using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace THOT.Models
{
    public class Question
    {
        public int QuestionId { get; set; }
        public int TestId { get; set; }
        public string Description { get; set; }
        public Test Test { get; set; }
    }
}