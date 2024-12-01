using BlogApp.DTOs.Request;
using BlogApp.DTOs.Response;

namespace BlogApp.Services.Interfaces;

public interface IUserLoginService
{
    Task<UserLoginResponseDTO> Login(UserRegisterRequestDTO userRegisterRequestDto);
}