using System.ComponentModel.DataAnnotations;

namespace GradingModule.Models
{
    public class Student
    {
        [Key]
        [Required]
        [MaxLength(10)]
        public string id { get; set; }
               
        [Required]
        [MaxLength(50)]
        public string fname { get; set; }

        [Required]
        public string depart { get; set; }

        [Required]
        [MaxLength(5)]
        public string student_batch { get; set; }

        [Required]
        public char current_sem { get; set; } = '1';

        [Required]
        [MaxLength(10)]
        public string gender { get; set; }  

        [Required]
        [MaxLength(50)]
        public string email { get; set; }

        [Required]
        [MaxLength(15)]
        public string contact_number { get; set; }
        [Required]
        [MaxLength(10)]
        public string section { get; set; }

        public string cgpa { get; set; }
        
    }
}

    // id        CHAR(10) NOT NULL,
    // fname             CHAR(50) NOT NULL,
    // depart VARCHAR NOT NULL,
    // student_batch VARCHAR(5) NOT NULL,
    // current_sem CHAR(1) NOT NULL DEFAULT "1",
    // gender char(10) NOT NULL,
    // email   varchar(50) ,
    // contact_number char(15) NOT NULL,
    // section varchar(10),
    // cgpa varchar,