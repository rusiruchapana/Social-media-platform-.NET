using BlogApp.Models;

namespace BlogApp.Repositories.Interfaces;

public interface IPostsRepository
{
    Task<Post> CreatePost(Post post);
}