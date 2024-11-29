using BlogApp.Data;
using BlogApp.Repositories.Interfaces;

namespace BlogApp.Repositories;

public class UserLoginRepository: IUserLoginRepository
{
    private readonly ApplicationDbContext _dbContext;

    public UserLoginRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
}