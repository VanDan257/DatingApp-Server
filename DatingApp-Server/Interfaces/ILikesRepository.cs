using DatingApp_Server.DTOs;
using DatingApp_Server.Entities;

namespace DatingApp_Server.Interfaces
{
    public interface ILikesRepository
    {
        Task<UserLike> GetUserLike(int sourceUserId, int targetUserId);
        Task<UserLike> GetUserWithLikes(int userId);
        Task<IEnumerable<LikeDto>> GetUserLikes(string predicate, int userId);
    }
}
