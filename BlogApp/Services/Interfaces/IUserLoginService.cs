using BlogApp.DTOs.Request;
using BlogApp.DTOs.Response;

namespace BlogApp.Services.Interfaces;

public interface IUserLoginService
{
    Task<UserLoginResponseDTO> Login(UserLoginRequestDTO userLoginRequestDto);
    Task LogoutUser(string token);
}