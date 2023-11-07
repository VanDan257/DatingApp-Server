using AutoMapper;
using Models.Data;
using Models.Entities;

namespace DatingApp_Server.Data
{
    public class MessageRepository
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public MessageRepository(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        public List<Message> GetMessagesInBoxChat(int userId, int chatRoomId)
        {
            return _context.Messages.Where(s => s.UserId == userId && s.RoomId == chatRoomId).ToList();
        }
    }
}
