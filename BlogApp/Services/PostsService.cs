using AutoMapper;
using BlogApp.DTOs.Request;
using BlogApp.DTOs.Response;
using BlogApp.Models;
using BlogApp.Repositories.Interfaces;
using BlogApp.Services.Interfaces;

namespace BlogApp.Services;

public class PostsService: IPostsService
{
    private readonly IPostsRepository _postsRepository;
    private readonly IMapper _mapper;

    public PostsService(IPostsRepository postsRepository , IMapper mapper)
    {
        _postsRepository = postsRepository;
        _mapper = mapper;
    }

    public async Task<PostsResponseDTO> CreatePost(PostsRequestDTO postsRequestDto)
    {
        Post post = _mapper.Map<Post>(postsRequestDto);
        Post savedPost = await _postsRepository.CreatePost(post);

        PostsResponseDTO postsResponseDto = _mapper.Map<PostsResponseDTO>(savedPost);
        
        return postsResponseDto;
    }

    public async Task<IEnumerable<PostsResponseDTO>> GetAllPosts()
    {
        IEnumerable<Post> posts = await _postsRepository.GetAllPosts();
        IEnumerable<PostsResponseDTO> postsResponseDtos = _mapper.Map<IEnumerable<PostsResponseDTO>>(posts);
        return postsResponseDtos;
    }

    public  async Task<PostsResponseDTO> GetPostById(int id)
    {
        Post post = await _postsRepository.GetPostById(id);
        PostsResponseDTO postsResponseDto = _mapper.Map<PostsResponseDTO>(post);
        return postsResponseDto;
    }

    public async Task<PostsResponseDTO> UpdatePost(int id, PostsRequestDTO postsRequestDto)
    {
        Post post = _mapper.Map<Post>(postsRequestDto);
        Post updatedPost = await _postsRepository.UpdatePost(id , post);
        PostsResponseDTO postsResponseDto = _mapper.Map<PostsResponseDTO>(updatedPost);
        return postsResponseDto;
    }

    public async Task<bool> DeletePost(int id)
    {
        bool isDeleted = await _postsRepository.DeletePost(id);
        return isDeleted;
    }
}