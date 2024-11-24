using AutoMapper;
using BlogApp.DTOs.Request;
using BlogApp.DTOs.Response;
using BlogApp.Models;

namespace BlogApp.Mappings;

public class PostsProfile: Profile
{
    public PostsProfile()
    {
        CreateMap< PostsRequestDTO , Post >();
        CreateMap< Post , PostsResponseDTO >();
    }
}