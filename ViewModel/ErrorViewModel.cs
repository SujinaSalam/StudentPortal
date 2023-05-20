namespace StudentPortal.ViewModel
{
    /// <summary>
    /// Class for handling the error display.
    /// </summary>
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}