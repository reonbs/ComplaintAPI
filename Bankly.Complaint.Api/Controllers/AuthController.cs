using System;
using System.Threading.Tasks;
using Bankly.Complaint.Service.Dto;
using Bankly.Complaint.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bankly.Complaint.Api.Controllers
{
    [Route("/api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginReqDto loginReqDto)
        {
            try
            {
                var login = await _authService.Login(loginReqDto);

                return Ok(login);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
