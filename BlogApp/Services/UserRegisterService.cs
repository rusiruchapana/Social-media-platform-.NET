using BlogApp.Repositories.Interfaces;
using BlogApp.Services.Interfaces;

namespace BlogApp.Services;

public class UserRegisterService: IUserRegisterService
{
    private readonly IUserRegisterRepository _userRegisterRepository;

    public UserRegisterService(IUserRegisterRepository userRegisterRepository)
    {
        _userRegisterRepository = userRegisterRepository;
    }
}