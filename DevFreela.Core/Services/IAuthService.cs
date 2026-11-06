using DevFreela.Domain.Entities;

namespace DevFreela.Domain.Services
{
    public interface IAuthService
    {
        string GenerateJwtToken(string email, string role);
    }
}
