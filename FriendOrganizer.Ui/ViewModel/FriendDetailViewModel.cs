//using FriendOrganizer.UI.Event;
//using FriendOrganizer.UI.Wrapper;
//using FriendOrganizer.UI.Data.Repositories;
//using Prism.Commands;
//using Prism.Events;
//using System.Threading.Tasks;
//using System.Windows.Input;

//namespace FriendOrganizer.UI.ViewModel
//{
//    public class FriendDetailViewModel : ViewModelBase, IFriendDetailViewModel
//    {
//        private IFriendRepository _friendRepository;
//        private IEventAggregator _eventAggregator;
//        private FriendWrapper _friend;

//        public FriendDetailViewModel(IFriendRepository friendRepository,
//            IEventAggregator eventAggregator)
//        {
//            _friendRepository = friendRepository;
//            _eventAggregator = eventAggregator;


//            SaveCommand = new DelegateCommand(OnSaveExecute, OnSaveCanExetute);
//        }

//        public async Task LoadAsync(int friendId)
//        {
//            var friend = await _friendRepository.GetByIdAsync(friendId);

//            Friend = new FriendWrapper(friend);

//            Friend.PropertyChanged += (s, e) =>
//            {
//                if (e.PropertyName == nameof(Friend))
//                {
//                    ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();
//                }
//            };

//            ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();
//        }

//        public FriendWrapper Friend
//        {
//            get { return _friend; }
//            private set
//            {
//                _friend = value;
//                OnPropertyChanged();
//            }
//        }

//        public ICommand SaveCommand { get; }

//        private async void OnSaveExecute()
//        {
//            await _friendRepository.SaveAsync();
//            _eventAggregator.GetEvent<AfterSaveFriendEvent>().Publish(
//                new AfterSaveFriendEventArgs
//                {
//                    Id = Friend.Id,
//                    DisplayMember = $"{Friend.FirstName} {Friend.LastName}"
//                });
//        }

//        private bool OnSaveCanExetute()
//        {
//            // TODO: Check in addition if friend has changes
//            return Friend!=null && !Friend.HasErrors;
//        }

//    }
//}


using FriendOrganizer.UI.Data.Repositories;
using FriendOrganizer.UI.Event;
using FriendOrganizer.UI.Wrapper;
using Prism.Commands;
using Prism.Events;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FriendOrganizer.UI.ViewModel
{
    public class FriendDetailViewModel : ViewModelBase, IFriendDetailViewModel
    {
        private IFriendRepository _friendRepository;
        private IEventAggregator _eventAggregator;
        private FriendWrapper _friend;
        private bool _hasChanges;

        public FriendDetailViewModel(IFriendRepository friendRepository,
            IEventAggregator eventAggregator)
        {
            _friendRepository = friendRepository;
            _eventAggregator = eventAggregator;


            SaveCommand = new DelegateCommand(OnSaveExecute, OnSaveCanExetute);
        }

        public async Task LoadAsync(int friendId)
        {
            var friend = await _friendRepository.GetByIdAsync(friendId);

            Friend = new FriendWrapper(friend);

            Friend.PropertyChanged += (s, e) =>
            {
                if (!HasChanges)
                {
                    HasChanges = _friendRepository.HasChanges();
                }
                if (e.PropertyName == nameof(Friend))
                {
                    ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();
                }
            };

            ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();
        }

        public FriendWrapper Friend
        {
            get { return _friend; }
            private set
            {
                _friend = value;
                OnPropertyChanged();
            }
        }

        public ICommand SaveCommand { get; }

        public bool HasChanges
        {
            get { return _hasChanges; }
            set {
                if (_hasChanges != value)
                {
                    _hasChanges = value;
                    OnPropertyChanged();
                    ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();
                }
            }
        }


        private async void OnSaveExecute()
        {
            await _friendRepository.SaveAsync();
            HasChanges = _friendRepository.HasChanges();
            _eventAggregator.GetEvent<AfterSaveFriendEvent>().Publish(
                new AfterSaveFriendEventArgs
                {
                    Id = Friend.Id,
                    DisplayMember = $"{Friend.FirstName} {Friend.LastName}"
                });
        }

        private bool OnSaveCanExetute()
        {
            return Friend != null && !Friend.HasErrors && HasChanges;
        }
    }
}