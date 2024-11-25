using BlogApp.Models;

namespace BlogApp.Repositories.Interfaces;

public interface ICommentsRepository
{
    Task<Comment> CreateComments(Comment comment);

    Task<IEnumerable<Comment>> GetComments(int postId);
}