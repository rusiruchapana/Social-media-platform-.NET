using BlogApp.Models;

namespace BlogApp.Repositories.Interfaces;

public interface IUserLoginRepository
{
    Task<User> GetUserByEmail(string email);
}