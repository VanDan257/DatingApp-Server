using DatingApp_Server.DTOs;
using DatingApp_Server.Entities;
using DatingApp_Server.Helpers;

namespace DatingApp_Server.Interfaces
{
    public interface IUserRepository
    {
        void Update(AppUser user);
        Task<bool> SaveAllAsync();
        Task<IEnumerable<AppUser>> GetUsersAsync();
        Task<AppUser> GetUserByIdAsync(int id);
        Task<AppUser> GetUserByNameAsync(string name);
        Task<PagedList<MemberDto>> GetMembersAsync(UserParam userParam);
        Task<MemberDto> GetMemberByNameAsync(string name);
    }
}
