using BlogApp.DTOs.Request;
using BlogApp.DTOs.Response;
using BlogApp.Models;
using BlogApp.Repositories.Interfaces;
using BlogApp.Security;
using BlogApp.Services.Interfaces;

namespace BlogApp.Services;

public class UserLoginService: IUserLoginService
{
    private readonly IUserLoginRepository _userLoginRepository;
    private readonly JwtTokenGenerator _jwtTokenGenerator;

    public UserLoginService(IUserLoginRepository userLoginRepository , JwtTokenGenerator jwtTokenGenerator)
    {
        _userLoginRepository = userLoginRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<UserLoginResponseDTO> Login(UserRegisterRequestDTO userRegisterRequestDto)
    {
        User user = await _userLoginRepository.GetUserByEmail(userRegisterRequestDto.Email);
        if (user == null || !BCrypt.Net.BCrypt.Verify(userRegisterRequestDto.PasswordHash, user.PasswordHash))
            throw new Exception("Invalid email or password");

        var token = _jwtTokenGenerator.GenerateToken(user);



        return new UserLoginResponseDTO
        {
            Token = token,
            Username = user.Username,
            Email = user.Email
        };
    }
}