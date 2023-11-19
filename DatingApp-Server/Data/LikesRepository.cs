using DatingApp_Server.DTOs;
using DatingApp_Server.Entities;
using DatingApp_Server.Interfaces;

namespace DatingApp_Server.Data
{
    public class LikesRepository : ILikesRepository
    {
        public Task<UserLike> GetUserLike(int sourceUserId, int targetUserId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<LikeDto>> GetUserLikes(string predicate, int userId)
        {
            throw new NotImplementedException();
        }

        public Task<UserLike> GetUserWithLikes(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
