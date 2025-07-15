namespace OtServer.Domain.Services
{
    public interface ITokenService
    {
        string GenerateToken(string id, string name, string role);
    }
}
