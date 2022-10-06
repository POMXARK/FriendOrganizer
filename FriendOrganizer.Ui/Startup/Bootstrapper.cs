using Autofac;
using FriendOrganizer.DataAccess;
using FriendOrganizer.Ui;
using FriendOrganizer.UI.Data;
using FriendOrganizer.UI.ViewModel;
using Prism.Events;

namespace FriendOrganizer.UI.Startup
{
    /// <summary>
    ///  https://www.calabonga.net/blog/post/wpf-prilozhenie-na-mvvm-s-ispolzovaniem-prism-6-i-autofac
    /// https://www.calabonga.net/blog/post/wpf-prilozhenie-na-mvvm-s-ispolzovaniem-prism-7-i-dependency-container
    /// </summary>
    public class Bootstrapper
    {
        public IContainer Bootstrap()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<EventAggregator>().As<IEventAggregator>().SingleInstance();
            builder.RegisterType<FriendOrganizerDbContext>().AsSelf();

            builder.RegisterType<MainWindow>().AsSelf();
            builder.RegisterType<MainViewModel>().AsSelf();
            builder.RegisterType<NavigationViewModel>().As<INavigationViewModel>();
            builder.RegisterType<FriendDetailViewModel>().As<IFriendDetailViewModel>();

            builder.RegisterType<LookupDataService>().AsImplementedInterfaces();
            builder.RegisterType<FriendDataService>().As<IFriendDataService>();
            

            return builder.Build();
        }

    }
}
