using AppChat_Server.DTOs;

using AppChat_Server.Helpers;
using Models.Entities;

namespace AppChat_Server.Interfaces
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
