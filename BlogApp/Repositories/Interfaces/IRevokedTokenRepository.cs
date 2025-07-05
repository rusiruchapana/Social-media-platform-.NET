namespace BlogApp.Repositories.Interfaces;

public interface IRevokedTokenRepository
{
    Task AddRevokedToken(string token, DateTime expiresAt);
    Task<bool> IsTokenRevokedAsync(string tokenRawData);
}