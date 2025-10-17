
namespace Application.DTOs
{
    public record LoginResponse(bool flag, string? message, string? token = null);
}
