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
}