using BlogApp.DTOs.Request;
using BlogApp.DTOs.Response;
using BlogApp.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Controllers;

[Route("api/[controller]")]
[ApiController]
[AllowAnonymous]
public class UserRegisterController: ControllerBase
{
    private readonly IUserRegisterService _userRegisterService;

    public UserRegisterController(IUserRegisterService userRegisterService)
    {
        _userRegisterService = userRegisterService;
    }


    [HttpPost]
    public async Task<IActionResult> RegisterUser(UserRegisterRequestDTO userRegisterRequestDTO)
    {
        UserRegisterResponseDTO userRegisterResponseDto = await _userRegisterService.RegisterUser(userRegisterRequestDTO);
        return Created("" , userRegisterResponseDto);
    }


}