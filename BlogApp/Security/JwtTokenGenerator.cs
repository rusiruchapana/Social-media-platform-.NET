using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BlogApp.Models;
using Microsoft.IdentityModel.Tokens;

namespace BlogApp.Security;

public class JwtTokenGenerator
{
    private readonly string _secretKey;
    private readonly string _issuer;
    private readonly string _audience;


    public JwtTokenGenerator(string secretKey, string issuer, string audience)
    {
        _secretKey = secretKey;
        _issuer = issuer;
        _audience = audience;
    }

    public string GenerateToken(User user)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
        var credentials = new SigningCredentials(securityKey , SecurityAlgorithms.HmacSha256Signature);

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub , user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Email , user.Email),
            new Claim(JwtRegisteredClaimNames.UniqueName , user.Username),
            new Claim("role" , "User")
        };


        var token = new JwtSecurityToken
        (
            issuer: _issuer,
            audience: _audience,
            claims: claims,
            expires: DateTime.Now.AddHours(1),
            signingCredentials: credentials
        );
        
        
        return new JwtSecurityTokenHandler().WriteToken(token);
    }

}