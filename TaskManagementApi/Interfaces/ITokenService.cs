using TaskManagementApi.Entities;

namespace TaskManagementApi.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}
