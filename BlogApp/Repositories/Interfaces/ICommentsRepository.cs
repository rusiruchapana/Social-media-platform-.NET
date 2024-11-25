using BlogApp.Models;

namespace BlogApp.Repositories.Interfaces;

public interface ICommentsRepository
{
    Task<Comment> CreateComments(Comment comment);

    Task<IEnumerable<Comment>> GetComments(int postId);
    Task<Comment> GetCommentById(int postId, int commentId);
}