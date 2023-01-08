using Behnam_BehnamAPI.Models;
using Behnam_BehnamAPI.Models.Dto;

namespace Behnam_BehnamAPI.Repository.IRepository
{
    public interface IUserRepository
    {
        Task<bool> IsUniqueUser(string username);
        Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO);
        Task<LocalUser> Register(RegistrationRequestDTO registrationRequestDTO);
    }
}
