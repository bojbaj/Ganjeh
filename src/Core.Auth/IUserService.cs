using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Auth.Models;

namespace Core.Auth
{
    public interface IUserService
    {
        Task<TypedResult<LoginResponse>> LoginAsync(LoginRequest model);
        Task<TypedResult<RegisterResponse>> RegisterAsync(RegisterRequest req, IEnumerable<string> roles);
    }
}