using Models.Entities;

namespace AppChat_Server.Interfaces
{
    public interface ITokenService
    {
        string CresteToken(AppUser user);
    }
}
