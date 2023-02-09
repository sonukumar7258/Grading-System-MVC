using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GradingModule.Models
{
    public class TeacherCourse
    {
        [Key,Column(Order = 1)]
        [Required]
        [ForeignKey("Teacher")]
        [MaxLength(10)]
        public string teacher_id { get; set; }

        [Key,Column(Order = 2)]
        [Required]
        [ForeignKey("Course")]
        [MaxLength(10)]
        public string course_id { get; set; } 

        [Key,Column(Order = 3)]
        [Required]      
        [MaxLength(10)]
        public string section { get; set; }
    }
}


    // id int IDENTITY(1,1) NOT NULL,
    // teacher_id int NOT NULL,
    // course_id int,
    // section CHAR,
    // created_at datetime default CURRENT_TIMESTAMP,
    // updated_at datetime default CURRENT_TIMESTAMP,
    // section varchar(10),

//     ALTER TABLE Teacher_Course ADD CONSTRAINT Teacher_Course_pk PRIMARY KEY ( teacher_id,course_id,section );
// ALTER TABLE Teacher_Course
//     ADD CONSTRAINT TC_t_fk FOREIGN KEY ( teacher_id )
//         REFERENCES Teacher ( id );
// ALTER TABLE Teacher_Course
//     ADD CONSTRAINT TC_C_fk FOREIGN KEY ( Course_id )
//         REFERENCES Course ( id );