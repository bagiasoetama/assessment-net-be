using System.ComponentModel.DataAnnotations;

namespace assessment_net_be.Models.Lecturer
{
    public class Lecturer
    {
        public int LECTURER_ID { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 0)]
        public string LECTURER_NAME { get; set; }
        public int LECTURER_DETAIL_ID { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 0)]
        public string LECTURER_ADDRESS { get; set; }
        [Required]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Please enter a numeric value.")]
        [StringLength(14, MinimumLength = 9)]
        public string LECTURER_TELP { get; set; }
        [Required]
        [EmailAddress]
        [StringLength(50, MinimumLength = 0)]
        public string LECTURER_EMAIL { get; set; }
    }
}