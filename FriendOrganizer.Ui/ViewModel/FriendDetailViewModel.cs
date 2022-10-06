using FriendOrganizer.Model;
using FriendOrganizer.Ui.Event;
using FriendOrganizer.UI.Data;
using Prism.Commands;
using Prism.Events;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

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

            SaveCommand = new DelegateCommand(OnSaveExecute, OnSaveCanExetute);
        }

        private async void OnSaveExecute()
        {
            await _dataService.SaveAsync(Friend);
            _eventAggregator.GetEvent<AfterSaveFriendEvent>().Publish(
                new AfterSaveFriendEventArgs
                {
                    Id = Friend.Id,
                    DisplayMember = $"{Friend.FirstName} {Friend.LastName}"
                });
        }

        private bool OnSaveCanExetute()
        {
            // TODO: check is friend is valid
            return true;
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

        public ICommand SaveCommand { get; }
    }
}
