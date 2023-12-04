namespace ivnet.club.services.api.Models
{
    public class ErrorLog
    {
        public string Id { get; set; }
        public string Service { get; set; }
        public string Method { get; set; }
        public string Message { get; set; }
        public string InnerMessage { get; set; }
    }
}