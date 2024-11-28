using BlogApp.Data;
using BlogApp.Repositories.Interfaces;

namespace BlogApp.Repositories;

public class UserRegisterRepository: IUserRegisterRepository
{
    private readonly ApplicationDbContext _dbContext;

    public UserRegisterRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
}