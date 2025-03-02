using TaskManagementApi.Entities;
using TaskManagementApi.DTOs.User;
using TaskManagementApi.DTOs.Token;

namespace TaskManagementApi.Services
{
    public interface IAuthService
    {
        Task<User?> RegisterAsync(UserDTO request);
        Task<TokenResponseDTO?> LoginAsync(UserDTO request);
        Task<TokenResponseDTO?> RefreshTokensAsync(RefreshTokenRequestDTO request);
    }
}
