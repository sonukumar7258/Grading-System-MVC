using System.ComponentModel.DataAnnotations;

namespace GradingModule.Models
{
    public class Teacher
    {
        [Key]
        [Required]
        [MaxLength(10)]
        public string id { get; set; }

        [Required]
        [MaxLength(50)]
        public string email { get; set; }
        [Required]
        [MaxLength(50)]
        public string designation { get; set; }
        [Required]
        [MaxLength(50)]
        public string name { get; set; }
        [Required]
        [MaxLength(50)]
        public string gender { get; set; }  
    }
}

// id int IDENTITY(1,1) NOT NULL,
//     email varchar(50) NOT NULL,
//     designation varchar(50) NOT NULL,
//     name varchar(50) NOT NULL,
//     gender varchar(50) NOT NULL,