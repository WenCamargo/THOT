using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;


namespace THOT.Models
{
    [Table("Question")]
    public class Question
    {
        public int QuestionId { get; set; }
        public int TestId { get; set; }
        [Required]
        [Display(Name = "Pregunta")]
        public string Description { get; set; }
        public Test Test { get; set; }
        public List<Answer> Answers { get; set; }
    }
}