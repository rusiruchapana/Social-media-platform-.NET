using blog_app.Data;
using blog_app.Repositories.Interfaces;

namespace blog_app.Repositories;

public class PostRepository: IPostRepository
{
    private readonly ApplicationDbContext _applicationDbContext;

    public PostRepository(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }
}