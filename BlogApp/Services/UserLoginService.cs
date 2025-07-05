using System.IdentityModel.Tokens.Jwt;
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
    private readonly IRevokedTokenRepository _revokedTokenRepository;

    public UserLoginService(IUserLoginRepository userLoginRepository , JwtTokenGenerator jwtTokenGenerator, IRevokedTokenRepository revokedTokenRepository)
    {
        _userLoginRepository = userLoginRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
        _revokedTokenRepository = revokedTokenRepository;
    }
    

    public async Task<UserLoginResponseDTO> Login(UserLoginRequestDTO userLoginRequestDto)
    {
        User user = await _userLoginRepository.GetUserByEmail(userLoginRequestDto.Email);
        if (user == null || !BCrypt.Net.BCrypt.Verify(userLoginRequestDto.PasswordHash, user.PasswordHash))
            throw new Exception("Invalid email or password");

        var token = _jwtTokenGenerator.GenerateToken(user);



        return new UserLoginResponseDTO
        {
            Token = token,
            Username = user.Username,
            Email = user.Email
        };
    }

    public async Task LogoutUser(string token)
    {
        var jwtTokenHandler = new JwtSecurityTokenHandler();
        var jwtToken = jwtTokenHandler.ReadJwtToken(token);
        var expiresAt = jwtToken.ValidTo;

        await _revokedTokenRepository.AddRevokedToken(token , expiresAt);
    }
}