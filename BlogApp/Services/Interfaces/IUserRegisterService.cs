using BlogApp.DTOs.Request;
using BlogApp.DTOs.Response;

namespace BlogApp.Services.Interfaces;

public interface IUserRegisterService
{
    Task<UserRegisterResponseDTO> RegisterUser(UserRegisterRequestDTO userRegisterRequestDto);
}