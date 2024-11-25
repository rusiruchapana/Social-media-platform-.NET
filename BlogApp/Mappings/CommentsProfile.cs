using AutoMapper;
using BlogApp.DTOs.Request;
using BlogApp.DTOs.Response;
using BlogApp.Models;

namespace BlogApp.Mappings;

public class CommentsProfile: Profile
{

    public CommentsProfile()
    {
        CreateMap<CommentsRequestDTO , Comment>();
        CreateMap<Comment , CommentsResponseDTO>();
    }
}