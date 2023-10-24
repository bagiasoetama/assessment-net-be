namespace assessment_net_be.Models
{
    public class ResponseMessage
    {
        public bool status { get; set; }
        public string message { get; set; }
        public string error { get; set; }
    }
}