using FriendOrganizer.UI.Event;
using Prism.Commands;
using Prism.Events;
using System.Windows.Input;

namespace FriendOrganizer.UI.ViewModel
{
    public class NavigationItemViewModel: ViewModelBase
    {
        private IEventAggregator _eventAggregator;
        private string _displayMember;

        public NavigationItemViewModel(int id, string displayMember,
            IEventAggregator eventAggregator)
        {
            Id = id;
            _eventAggregator = eventAggregator;
            DisplayMember = displayMember;
            OpenFriendDetailViewCommand = new DelegateCommand(OnOpenFriendDetailView);
        }

        public int Id { get; }

        public string DisplayMember
        {
            get { return _displayMember; }
            set { 
                _displayMember = value; 
                OnPropertyChanged();
            }
        }

        public ICommand OpenFriendDetailViewCommand { get; }


        private void OnOpenFriendDetailView()
        {
            _eventAggregator.GetEvent<OpenFriendDetailViewEvent>()
            .Publish(Id);
        }
    }
}
