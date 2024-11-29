using BlogApp.Models;

namespace BlogApp.Repositories.Interfaces;

public interface IUserRegisterRepository
{
    Task<User> RegisterUser(User user);
    Task<object> checkUsername(string username);
    Task<object> checkEmail(string email);
}