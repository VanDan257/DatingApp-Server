using DatingApp_Server.Entities;

namespace DatingApp_Server.Interfaces
{
    public interface ITokenService
    {
        string CresteToken(AppUser user);
    }
}
