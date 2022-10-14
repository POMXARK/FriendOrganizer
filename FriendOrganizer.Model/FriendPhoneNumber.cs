
namespace FriendOrganizer.Model
{
    public class FriendPhoneNumber
    {
        public int Id { get; set; }

        public string? Number { get; set; }

        public int? FriendId { get; set; }

        public Friend? Friend { get; set; }
    }
}
