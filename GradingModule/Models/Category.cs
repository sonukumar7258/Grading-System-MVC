using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GradingModule.Models
{
    public class Category
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

        [Required]
        [MaxLength(15)]
        public String CategoryName { get; set; }

        [Required]
        public int CategoryNameSequence { get; set; }
        [Required]
        public double marks { get; set; } = 0.0;

        [Required]
        public double TotalMarks { get; set; } = 0.0;
    }
}