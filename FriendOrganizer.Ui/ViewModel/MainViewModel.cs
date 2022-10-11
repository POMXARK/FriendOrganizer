//using FriendOrganizer.UI.Event;
//using Prism.Events;
//using System;
//using System.Threading.Tasks;

//namespace FriendOrganizer.UI.ViewModel
//{
//    public class MainViewModel : ViewModelBase
//    {
//        private Func<IFriendDetailViewModel> friendDetailViewModelCreator; 

//        public MainViewModel(INavigationViewModel navigationViewModel,
//            //Func<IFriendDetailViewModel> friendDetailViewModelCreator,
//            IEventAggregator eventAggregator)
//        {
//            _eventAggregator = eventAggregator;
//            //_friendDetailViewModelCreator = friendDetailViewModelCreator;

//            _eventAggregator.GetEvent<OpenFriendDetailViewEvent>()
//            .Subscribe(OnOpenFriendDetailView);

//            NavigationViewModel = navigationViewModel;
//        }

//        private async void OnOpenFriendDetailView(int friendId)
//        {
//            //await LoadAsync(friendId);
//        }

//        public void Load()
//        {
//        }

//        public async Task LoadAsync()
//        {
//            await NavigationViewModel.LoadAsync();
//        }

//        private IEventAggregator _eventAggregator;

//        public INavigationViewModel NavigationViewModel { get; }

//        public IFriendDetailViewModel _friendDetailViewModelCreator { get; }
//    }
//}



using System.Threading.Tasks;

namespace FriendOrganizer.UI.ViewModel
{
    public class MainViewModel : ViewModelBase
    {

        public MainViewModel(INavigationViewModel navigationViewModel,
            IFriendDetailViewModel friendDetailViewModel)
        {
            NavigationViewModel = navigationViewModel;
            FriendDetailViewModel = friendDetailViewModel;
        }

        public void Load()
        {
        }

        public async Task LoadAsync()
        {
            await NavigationViewModel.LoadAsync();
        }

        public INavigationViewModel NavigationViewModel { get; }

        public IFriendDetailViewModel FriendDetailViewModel { get; }
    }
}