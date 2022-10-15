﻿using FriendOrganizer.UI.Event;
using Prism.Commands;
using Prism.Events;
using System.Windows.Input;

namespace FriendOrganizer.UI.ViewModel
{
    public class NavigationItemViewModel: ViewModelBase
    {
        private IEventAggregator _eventAggregator;
        private string _displayMember;
        private string _detailViewModelName;

        public NavigationItemViewModel(int id, string displayMember,
            string detailViewModelName,
            IEventAggregator eventAggregator)
        {
            Id = id;
            _eventAggregator = eventAggregator;
            DisplayMember = displayMember;
            _detailViewModelName = detailViewModelName;
            OpenDetailViewCommand = new DelegateCommand(OnOpenDetailViewExecute);
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

        public ICommand OpenDetailViewCommand { get; }


        private void OnOpenDetailViewExecute()
        {
            _eventAggregator.GetEvent<OpenDetailViewEvent>()
            .Publish(
                new OpenDetailViewEventArgs
                {
                    Id = Id,
                    ViewModelName = _detailViewModelName,
                });
        }
    }
}
