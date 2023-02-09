using System.ComponentModel.DataAnnotations;

namespace GradingModule.Models
{
    public class Course
    {
        [Key]
        [Required]
        [MaxLength(10)]
        public string id { get; set; }

        [Required]
        [MaxLength(15)]
        public string name { get; set; }

        public int credithours { get; set; }

         [MaxLength(40)]
        public string pre_requisite { get; set; }


    }
}


    // id            INTEGER NOT NULL,
    // name       CHAR(30) NOT NULL,
    // credithours      INTEGER,
    // pre_requisite varchar(40),




