using System.ComponentModel.DataAnnotations;

namespace Models.Entities
{
    public class Message
    {
        [Key]
        public int Id { get; set; }
        public int RoomId { get; set; }
        public int UserId { get; set; }
        public string Content { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
