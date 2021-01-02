using System.Threading.Tasks;
using Core.Auth.Models;

namespace Core.Auth
{
    public interface IUserService
    {
        Task<LoginResponse> LoginAsync(LoginRequest model);
        Task<RegisterResponse> RegisterAsync(RegisterRequest req);
    }
}