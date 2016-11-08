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
        [Display(Name = "Test")]
        public int TestId { get; set; }
        [Display(Name = "Tema")]
        public int TopicId { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Nombre")]
        //[RegularExpression("^[A-Za-z]+$", ErrorMessage = "Sólo se admiten letras")]
        public string Name { get; set; }
        public Topic Topic { get; set; }
        public List<Question> Questions { get; set; }


    }
}