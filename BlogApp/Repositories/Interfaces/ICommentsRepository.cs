using BlogApp.Models;

namespace BlogApp.Repositories.Interfaces;

public interface ICommentsRepository
{
    Task<Comment> CreateComments(Comment comment);
}