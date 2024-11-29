using AutoMapper;
using BlogApp.DTOs.Request;
using BlogApp.DTOs.Response;
using BlogApp.Models;

namespace BlogApp.Mappings;

public class UserProfile: Profile
{
    public UserProfile()
    {
        CreateMap<UserRegisterRequestDTO , User>();
        CreateMap<User , UserRegisterResponseDTO>();
    }
}