using System.Collections.ObjectModel;

namespace FriendOrganizer.Model
{
    public class Meeting
    {
        public Meeting()
        {
            Friends = new Collection<Friend>();
        }
        public int Id { get; set; }

        public string? Title { get; set; }

        public DateTime DateFrom { get; set; }

        public DateTime DateTo { get; set; }

        public ICollection<Friend>? Friends {get; set; }
    }
}
