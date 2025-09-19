using E_CommerceBackend.Dtos.AuthDtos;

namespace E_CommerceBackend.Services.IServices
{
    public interface IAccountService
    {
        Task<bool> RegisterAsync(RegisterDto registerDto);
        Task<string> LoginAsync(LoginDto loginDto);
    }
}
