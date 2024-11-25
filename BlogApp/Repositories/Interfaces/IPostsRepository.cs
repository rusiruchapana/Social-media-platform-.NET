using BlogApp.Models;

namespace BlogApp.Repositories.Interfaces;

public interface IPostsRepository
{
    Task<Post> CreatePost(Post post);

    Task<IEnumerable<Post>> GetAllPosts();
    Task<Post> GetPostById(int id);
    Task<Post> UpdatePost(int id, Post post);
    Task<bool> DeletePost(int id);
}