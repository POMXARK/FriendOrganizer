using FriendOrganizer.Model;
using FriendOrganizer.Ui.Event;
using FriendOrganizer.UI.Data;
using Prism.Events;
using System.Threading.Tasks;

namespace FriendOrganizer.UI.ViewModel
{
    public class FriendDetailViewModel : ViewModelBase, IFriendDetailViewModel
    {
        private IFriendDataService _dataService;
        private IEventAggregator _eventAggregator;

        public FriendDetailViewModel(IFriendDataService dataService,
            IEventAggregator eventAggregator)
        {
            _dataService = dataService;
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<OpenFriendDetailViewEvent>()
                .Subscribe(OnOpenFriendDetailView);
        }

        private async void OnOpenFriendDetailView(int friendId)
        {
            await LoadAsync(friendId);
        }

        public async Task LoadAsync(int friendId)
        {
           Friend = await _dataService.GetByIdAsync(friendId);
        }

        private Friend _friend;

        public Friend Friend
        {
            get { return _friend; }
            private set {
                _friend = value; 
                OnPropertyChanged();
            }
        }
    }
}
