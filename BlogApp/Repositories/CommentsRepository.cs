using BlogApp.Data;
using BlogApp.Repositories.Interfaces;

namespace BlogApp.Repositories;

public class CommentsRepository: ICommentsRepository
{
    private readonly ApplicationDbContext _context;

    public CommentsRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
}