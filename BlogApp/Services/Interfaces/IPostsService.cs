

using BlogApp.DTOs.Request;
using BlogApp.DTOs.Response;

namespace BlogApp.Services.Interfaces;

public interface IPostsService
{
    Task<PostsResponseDTO> CreatePost(PostsRequestDTO postsRequestDto);

    Task<IEnumerable<PostsResponseDTO>> GetAllPosts();
    Task<PostsResponseDTO> GetPostById(int id);
    Task<PostsResponseDTO> UpdatePost(int id, PostsRequestDTO postsRequestDto);
    Task<bool> DeletePost(int id);
}