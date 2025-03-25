namespace OpenCartAPI.Helpers
{
    public class GlobalHelper
    {
    }
    public class ResponseResult
    {
        public bool Status { get; set; }
        public string? Message { get; set; } = string.Empty;
        public dynamic Data { get; set; } = null;
    }
}
