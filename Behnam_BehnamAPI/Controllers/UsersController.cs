using Behnam_BehnamAPI.Models;
using Behnam_BehnamAPI.Models.Dto;
using Behnam_BehnamAPI.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace Behnam_BehnamAPI.Controllers
{
    [Route("api/UsersAuth")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IUserRepository userRepository;
        protected APIResponse _response;
        public UsersController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
            this._response = new();
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO loginRequestDTO)
        {
            var loginresponse = await userRepository.Login(loginRequestDTO);
            if (loginresponse.User == null || string.IsNullOrEmpty(loginresponse.Token))
            {
                _response.IsSuccess = false;
                _response.ErrorMessages.Add("NOT VALID USER");
                _response.httpStatusCode = System.Net.HttpStatusCode.BadRequest;
                return BadRequest(_response);
            }
            _response.IsSuccess = true;
            _response.httpStatusCode = System.Net.HttpStatusCode.OK;
            _response.Result = loginresponse;
            return Ok(_response);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegistrationRequestDTO registrationRequestDTO)
        {
            bool isUserUnique = await userRepository.IsUniqueUser(registrationRequestDTO.UserName);
            if (!isUserUnique)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages.Add("USER NAME ALREADY EXISTS");
                _response.httpStatusCode = System.Net.HttpStatusCode.BadRequest;
                return BadRequest(_response);
            }
            var user = await userRepository.Register(registrationRequestDTO);
            if(user == null)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages.Add("ERROR WHILE REGISTERING");
                _response.httpStatusCode = System.Net.HttpStatusCode.BadRequest;
                return BadRequest(_response);
            }
            _response.httpStatusCode = System.Net.HttpStatusCode.OK;
            _response.IsSuccess = true;
            return Ok(_response);
        }
    }
}
