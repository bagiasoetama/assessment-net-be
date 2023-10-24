using System.ComponentModel.DataAnnotations;

namespace assessment_net_be.Models.Subject
{
    public class SubjectList
    {
        public int SUBJECT_LIST_ID { get; set; }
        public int STUDENT_ID { get; set; }
        public int SUBJECT_ID { get; set; }
    }
}