namespace POS.Models
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }
        public Exception Error { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
