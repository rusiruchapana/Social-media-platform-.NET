using BlogApp.Services.Interfaces;
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
    
}