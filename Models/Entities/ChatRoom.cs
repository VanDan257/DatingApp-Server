using System.ComponentModel.DataAnnotations;

namespace Models.Entities
{
    public class ChatRoom
    {
        [Key]
        public int Id { get; set; }
        public int RoomTypeId { get; set; }
        public string RoomName { get; set; }
    }
}
