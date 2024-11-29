using AutoMapper;
using BlogApp.DTOs.Request;
using BlogApp.DTOs.Response;
using BlogApp.Models;
using BlogApp.Repositories.Interfaces;
using BlogApp.Services.Interfaces;
using Microsoft.Win32.SafeHandles;

namespace BlogApp.Services;

public class UserRegisterService: IUserRegisterService
{
    private readonly IUserRegisterRepository _userRegisterRepository;
    private readonly IMapper _mapper;

    public UserRegisterService(IUserRegisterRepository userRegisterRepository , IMapper mapper)
    {
        _userRegisterRepository = userRegisterRepository;
        _mapper = mapper;
    }

    public async Task<UserRegisterResponseDTO> RegisterUser(UserRegisterRequestDTO userRegisterRequestDto)
    {
        var existingUsername = await _userRegisterRepository.checkUsername(userRegisterRequestDto.Username);
        if (existingUsername != null)
            throw new Exception("Username already exists");

        var existingEmail = await _userRegisterRepository.checkEmail(userRegisterRequestDto.Email);
        if(existingEmail != null)
            throw new Exception("Email already exists");
        
        userRegisterRequestDto.PasswordHash = BCrypt.Net.BCrypt.HashPassword(userRegisterRequestDto.PasswordHash);
        
        
        User user = _mapper.Map<User>(userRegisterRequestDto);
        User registeredUser = await _userRegisterRepository.RegisterUser(user);

        UserRegisterResponseDTO userRegisterResponseDto = _mapper.Map<UserRegisterResponseDTO>(registeredUser);
        return userRegisterResponseDto;
    }
}