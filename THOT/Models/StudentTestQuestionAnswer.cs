using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace THOT.Models
{
    public class StudentTestQuestionAnswer
    {
        public int StudentTestQuestionAnswerId { get; set;}
        public string UserId { get; set; }
        public int TestId { get; set; }
        public int QuestionId { get; set; }
        public int AnswerId { get; set; }
    }
}