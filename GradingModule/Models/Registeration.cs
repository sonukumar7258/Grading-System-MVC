using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GradingModule.Models
{
    public class Registeration
    {
        [Key,Column(Order = 1)]
        [Required]
        [ForeignKey("Student")]
        [MaxLength(10)]
        public string stud_id { get; set; }

        [Key,Column(Order = 2)]
        [Required]
        [ForeignKey("Course")]
        [MaxLength(10)]
        public string course_id { get; set; }
        
        [MaxLength(10)]
        public string section { get; set; }

        [MaxLength(10)]
        public string c_status { get; set; }

        [MaxLength(15)]
        public string pre_requisite { get; set; }

    }
}

// CREATE TABLE REGISTRATION (
//     --CHANGE THIS FOR COURSE REGISTRATION MODULE
//     stud_id CHAR(10) NOT NULL ,
//     course_id int,
//     section varchar(10),
//     c_status varchar(10),
//     pre_requisite varchar(15),
//     created_at datetime default CURRENT_TIMESTAMP,
//     updated_at datetime default CURRENT_TIMESTAMP
// );
// ALTER TABLE REGISTRATION ADD CONSTRAINT reg_pk PRIMARY KEY (stud_id,course_id);

// ALTER TABLE REGISTRATION
//     ADD CONSTRAINT reg_stud_fk FOREIGN KEY ( stud_id )
//         REFERENCES student ( id );

// ALTER TABLE REGISTRATION
//     ADD CONSTRAINT reg_course_fk FOREIGN KEY ( course_id )
//         REFERENCES course ( id );