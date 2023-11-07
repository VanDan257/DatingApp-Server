namespace DatingApp_Server.DTOs
{
    public class MessageDto
    {
        public string Content { get; set; }
        public string RoomName { get; set; }
        public string UserName { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
