using Prism.Events;

namespace FriendOrganizer.Ui.Event
{
    public class AfterSaveFriendEvent:PubSubEvent<AfterSaveFriendEventArgs>
    {
    }

    public class AfterSaveFriendEventArgs
    {
        public int Id { get; set; }
        public string DisplayMember { get; set; }

    }
}
