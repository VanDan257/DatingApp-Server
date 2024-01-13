using DatingApp_Server.DTOs;
using DatingApp_Server.Entities;
using DatingApp_Server.Helpers;

namespace DatingApp_Server.Interfaces
{
    public interface IMessageRepository
    {
        void AddMessage(Message message);
        void DeleteMessage(Message message);
        Task<Message> GetMessage(int id);
        Task<PagedList<MessageDto>> GetMessagesForUser(MessageParams messageParams);
        Task<IEnumerable<MessageDto>> GetMessageThread(string currentUserName, string recipientName);
    }
}
