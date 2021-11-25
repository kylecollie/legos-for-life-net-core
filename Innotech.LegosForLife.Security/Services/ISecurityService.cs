using InnoTech.LegosForLife.Security.Models;

namespace InnoTech.LegosForLife.Security.Services
{
    public interface ISecurityService
    {
        JwtToken GenerateJwtToken(string username, string password);
    }
}
