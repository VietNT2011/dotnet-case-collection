
using Application.DTOs;

namespace Application.Contracts
{
    public interface IUser
    {
        Task<RegistrationResponse> RegisterAsync(RegisterUserDTO registerUserDTO);
        Task<LoginResponse> LoginAsync(LoginDTO loginDTO);
    }
}
