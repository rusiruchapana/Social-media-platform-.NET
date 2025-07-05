using BlogApp.DTOs.Request;
using BlogApp.DTOs.Response;
using BlogApp.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Controllers;

[Route("api/[controller]")]
[ApiController]

public class UserLoginController: ControllerBase
{
    private readonly IUserLoginService _userLoginService;

    public UserLoginController(IUserLoginService userLoginService)
    {
        _userLoginService = userLoginService;
    }

    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<IActionResult> Login(UserLoginRequestDTO userLoginRequestDto)
    {
        try
        {
            UserLoginResponseDTO userLoginResponseDto = await _userLoginService.Login(userLoginRequestDto);
            return Ok(userLoginResponseDto);
        }
        catch (Exception e)
        {
            return Unauthorized(new { message = e.Message });
        }
    }

    [HttpPost("logout")]
    [Authorize]
    public async Task<IActionResult> Logout()
    {
        try
        {
            var token = Request.Headers["Authorization"].ToString().Replace("Bearer", "").Trim();
            await _userLoginService.LogoutUser(token);
            return Ok("Logged out");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            Console.WriteLine(e.InnerException?.Message);
            return StatusCode(500, "An error occurred while logging out.");
        }
    }




}