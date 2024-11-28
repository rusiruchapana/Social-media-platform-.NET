using BlogApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserRegisterController: ControllerBase
{
    private readonly IUserRegisterService _userRegisterService;

    public UserRegisterController(IUserRegisterService userRegisterService)
    {
        _userRegisterService = userRegisterService;
    }
}