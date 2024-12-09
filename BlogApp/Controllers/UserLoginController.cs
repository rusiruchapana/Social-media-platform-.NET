using BlogApp.DTOs.Request;
using BlogApp.DTOs.Response;
using BlogApp.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Controllers;

[Route("api/[controller]")]
[ApiController]
[AllowAnonymous]
public class UserLoginController: ControllerBase
{
    private readonly IUserLoginService _userLoginService;

    public UserLoginController(IUserLoginService userLoginService)
    {
        _userLoginService = userLoginService;
    }

    [HttpPost]
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


}