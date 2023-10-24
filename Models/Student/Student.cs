using System.ComponentModel.DataAnnotations;

namespace assessment_net_be.Models.Student
{
    public class Student
    {
        public int STUDENT_ID { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 0)]
        public string STUDENT_NAME { get; set; }
    }
}