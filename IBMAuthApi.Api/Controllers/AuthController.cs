using IBMAuthApi.Api.Exceptions;
using IBMAuthApi.Api.Services.Login;
using IBMAuthApi.Api.Services.Register;
using IBMAuthApi.Api.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace IBMAuthApi.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private ILoginService _loginService;
        private IRegisterService _registerService;

        //Add Swagger
        //Add DbContext
        //Add DB Connection
        //Register Users

        public AuthController(
            ILoginService loginService, 
            IRegisterService registerService)
        {
            _loginService = loginService;
            _registerService = registerService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(string username, string password)
        {
            try
            {
                var token = await _loginService.Login(username, password);
                return Ok(token);
            }
            catch(UserNotFoundException unf)
            {
                return Unauthorized(unf.Message);
            }
            catch (PasswordIncorrectException pie)
            {
                return Unauthorized(pie.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //[Authorize]
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            try
            {
                await _registerService.RegisterUser(registerDto);
                return Ok("User created");
            }
            catch(UserAlreadyExistsException uae)
            {
                return Conflict(uae.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
