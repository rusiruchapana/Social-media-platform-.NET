using BlogApp.Data;
using BlogApp.Models;
using BlogApp.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Repositories;

public class RevokedTokenRepository: IRevokedTokenRepository
{
    
    private readonly ApplicationDbContext _dbContext;

    public RevokedTokenRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddRevokedToken(string token, DateTime expiresAt)
    {
        var RevokedToken = new RevokedToken
        {
            Token = token,
            RevokedAt = DateTime.UtcNow,
            ExpiresAt = expiresAt
        };

        _dbContext.RevokedTokens.Add(RevokedToken);
        await _dbContext.SaveChangesAsync();
        
    }

    public async Task<bool> IsTokenRevokedAsync(string tokenRawData)
    {
        return await _dbContext.RevokedTokens.AnyAsync(rt => rt.Token == tokenRawData);
    }
}