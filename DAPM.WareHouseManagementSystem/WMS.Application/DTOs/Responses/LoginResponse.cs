namespace WMS.Application.DTOs.Responses
{
    public record LoginResponse(bool Succeeded = false, string Message = null!, string Token = null!, string RefreshToken = null!);
}
