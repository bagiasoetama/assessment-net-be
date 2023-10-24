using System.ComponentModel.DataAnnotations;

namespace assessment_net_be.Models.Subject
{
    public class Subject
    {
        public int SUBJECT_ID { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 0)]
        public string SUBJECT_NAME { get; set; }
    }
}