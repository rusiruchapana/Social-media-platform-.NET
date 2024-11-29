using BlogApp.Repositories.Interfaces;
using BlogApp.Services.Interfaces;

namespace BlogApp.Services;

public class UserLoginService: IUserLoginService
{
    private readonly IUserLoginRepository _userLoginRepository;

    public UserLoginService(IUserLoginRepository userLoginRepository)
    {
        _userLoginRepository = userLoginRepository;
    }
}