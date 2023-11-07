using System.ComponentModel.DataAnnotations;

namespace Models.Entities
{
    public class ChatRoomType
    {
        [Key]
        public int Id { get; set; }
        public string RoomType { get; set; }
    }
}
