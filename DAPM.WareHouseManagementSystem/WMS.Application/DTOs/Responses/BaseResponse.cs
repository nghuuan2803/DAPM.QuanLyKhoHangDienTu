namespace WMS.Application.DTOs.Responses
{
    public class BaseResponse
    {
        public bool Succeeded { get; set; } = true;
        public string? Message { get; set; }
        public object? Data { get; set; }
        public BaseResponse(bool succeeded = true, string message = null!, object data = null!)
        {
            Succeeded = succeeded;
            Message = message;
            Data = data;
        }
    }
}
