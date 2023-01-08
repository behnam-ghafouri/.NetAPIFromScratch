using Behnam_BehnamAPI.Data;
using Behnam_BehnamAPI.Models;
using Behnam_BehnamAPI.Models.Dto;
using Behnam_BehnamAPI.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;
namespace Behnam_BehnamAPI.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly string SecretKey;
        public UserRepository(ApplicationDbContext db,IConfiguration configuration)
        {
            _db=db;
            SecretKey = configuration.GetValue<string>("ApiSettings:Secret");
        }
        async Task<bool> IUserRepository.IsUniqueUser(string username)
        {
            var user = await _db.LocalUsers.FirstOrDefaultAsync(x=>x.UserName==username);
            if (user == null)
                return true;
            return false;
        }

        async Task<LoginResponseDTO> IUserRepository.Login(LoginRequestDTO loginRequestDTO)
        {
            var user = await _db.LocalUsers.FirstOrDefaultAsync(u=>u.UserName.ToLower() == loginRequestDTO.UserName.ToLower() 
            && u.Password==loginRequestDTO.Password);
            if (user == null)
            {
                return new LoginResponseDTO()
                {
                    Token = "",
                    User = null,
                };
            }

            //generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name,user.Id.ToString()),
                    new Claim(ClaimTypes.Role,user.Role)
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new(new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new LoginResponseDTO()
            {
                Token = tokenHandler.WriteToken(token),
                User = user,
            };
        }

        async Task<LocalUser> IUserRepository.Register(RegistrationRequestDTO registrationRequestDTO)
        {
            LocalUser user = new()
            {
                UserName = registrationRequestDTO.UserName,
                Name = registrationRequestDTO.Name,
                Role = registrationRequestDTO.Role,
                Password = registrationRequestDTO.Password,
            };
            _db.LocalUsers.Add(user);
            await _db.SaveChangesAsync();
            user.Password = "";
            return user;
        }
    }
}
