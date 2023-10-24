using System.ComponentModel.DataAnnotations;

namespace assessment_net_be.Models.Subject
{
    public class SubjectLecturer
    {
        public int SUBJECT_LECTURER_ID { get; set; }
        public int SUBJECT_ID { get; set; }
        public int LECTURER_ID { get; set; }
    }
}