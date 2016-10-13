using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace THOT.Models
{
    [Table("Test")]
    public class Test
    {
        public int TestId { get; set; }
        public int TopicId { get; set; }
        public string Name { get; set; }
        public Topic Topic { get; set; }
        public List<Question> Questions { get; set; }


    }
}