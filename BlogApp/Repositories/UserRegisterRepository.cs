using BlogApp.Data;
using BlogApp.Models;
using BlogApp.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Repositories;

public class UserRegisterRepository: IUserRegisterRepository
{
    private readonly ApplicationDbContext _dbContext;

    public UserRegisterRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<User> RegisterUser(User user)
    {
        _dbContext.Users.Add(user);
        await _dbContext.SaveChangesAsync();    
        return user;
    }

    public async Task<object> checkUsername(string username)
    {
        return await _dbContext.Users.FirstOrDefaultAsync(u => u.Username == username);
    }

    public async Task<object> checkEmail(string email)
    {
        return await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
    }
}