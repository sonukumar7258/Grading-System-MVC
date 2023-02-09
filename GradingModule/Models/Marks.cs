using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GradingModule.Models
{
    public class Marks
    {
        [Key,Column(Order = 1)]
        [Required]
        [MaxLength(10)]
        public string stud_id { get; set; }

        [Key,Column(Order = 2)]
        [Required]
        [MaxLength(10)]
        public string course_id { get; set; }

        [Required]
        public double marks { get; set; } = 0.0;

                
        [Required]
        public char semester { get; set; } = '1';
        
        [Required]
        [MaxLength(5)]
        public string grade { get; set; }

        [ForeignKey("stud_id")]
        public virtual Student Students { get; set; }

        [ForeignKey("course_id")]
        public virtual Course Courses { get; set; }
    }
}

// CREATE TABLE MARKS(
//     grade varchar(5) NOT NULL,
//     stud_id CHAR(10) NOT NULL ,
//     course_id VARCHAR(10) NOT NULL,
//     marks NUMBER NOT NULL DEFAULT 0,
//     semester VARCHAR (12),
//     created_at datetime default CURRENT_TIMESTAMP,
//     updated_at datetime default CURRENT_TIMESTAMP
// );
// ALTER TABLE MARKS ADD CONSTRAINT marks_pk PRIMARY KEY (course_id,stud_id);

// ALTER TABLE MARKS
//     ADD CONSTRAINT reg_stud_fk FOREIGN KEY ( stud_id )
//         REFERENCES student ( id );

// ALTER TABLE MARKS
//     ADD CONSTRAINT reg_course_fk FOREIGN KEY ( course_id )
//         REFERENCES course ( id );