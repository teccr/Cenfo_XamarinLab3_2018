using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Cenfo_XamarinLab3_2018.Models;
using Cenfo_XamarinLab3_2018.Views;
using Xamarin.Forms;

namespace Cenfo_XamarinLab3_2018.ViewModels
{
    public class MapPointsViewModel : ViewModelBase
    {
        #region Singleton Definition

        private static MapPointsViewModel instance = null;

        public static MapPointsViewModel GetInstance()
        {
            if (instance == null)
            {

                instance = new MapPointsViewModel();
            }

            return instance;
        }

        public static void DeleteInstance()
        {
            if (instance != null)
            {
                instance = null;
            }
        }

        public MapPointsViewModel()
        {
            InitCommands();
            InitClass();
        }

        #endregion

        #region Properties

        private ObservableCollection<MenuItemModel> _menuItems;
        public ObservableCollection<MenuItemModel> MenuItems
        {
            get
            {
                return _menuItems;
            }
            set
            {
                _menuItems = value;
                OnPropertyChanged("MenuItems");
            }
        }

        #endregion

        #region Init View Model

        private void InitCommands()
        {
            GoToAddPointCommand = new Command(GoToAddPoint);
            GoToPointListCommand = new Command(GoToPointList);
            GoToMapCommand = new Command(GoToMap);
            SaveNewPointCommand = new Command(SaveNewPoint);
        }

        private void InitClass()
        {
            ObservableCollection<MenuItemModel> menuItems = new ObservableCollection<MenuItemModel>();
            menuItems.Add(new MenuItemModel()
            {
                Description = "Add a new point to the map",
                Name = "Add Point",
                Icon = "add",
                Command = GoToAddPointCommand
            });
            menuItems.Add(new MenuItemModel()
            {
                Description = "List all points",
                Name = "List Points",
                Icon = "list",
                Command = GoToPointListCommand
            });
            menuItems.Add(new MenuItemModel()
            {
                Description = "View all your points in a map",
                Name = "View map",
                Icon = "map",
                Command = GoToMapCommand
            });

            MenuItems = menuItems;

            MapPoints = new ObservableCollection<MapPointModel>();
            MapPoints.Add( new MapPointModel() 
                { 
                    Description = "Simple vacation time",
                    Latitude = "47.12",
                    Longitude = "58.12",
                    Name = "Vacation Time"
                } );
        }

        #endregion

        #region Properties

        private ObservableCollection<MapPointModel> _mapPoints;
        public ObservableCollection<MapPointModel> MapPoints
        {
            get 
            {
                return _mapPoints;
            }
            set 
            {
                _mapPoints = value;
                OnPropertyChanged("MapPoints");
            }
        }

        private MapPointModel _currentMapPoint;
        public MapPointModel CurrentMapPoint
        {
            get {
                return _currentMapPoint;
            }
            set {
                _currentMapPoint = value;
                OnPropertyChanged("CurrentMapPoint");
            }
        }

        #endregion

        #region Commands

        public ICommand GoToAddPointCommand
        {
            get;
            set;
        }

        private void GoToAddPoint()
        {
            CurrentMapPoint = new MapPointModel();
            var masterDetailPage = App.Current.MainPage as MasterDetailPage;
            if(masterDetailPage != null && !(
                GetCurrentPage() is AddMapPointView))
            {
                masterDetailPage.Detail.Navigation.PushAsync(new AddMapPointView());
            }
            masterDetailPage.IsPresented = false;
        }

        public ICommand GoToPointListCommand
        {
            get;
            set;
        }

        private void GoToPointList()
        {
            var masterDetailPage = App.Current.MainPage as MasterDetailPage;
            if (masterDetailPage != null && !(
                GetCurrentPage() is MapPointsListView))
            {
                masterDetailPage.Detail.Navigation.PushAsync(new MapPointsListView());
            }
            masterDetailPage.IsPresented = false;
        }

        public ICommand GoToMapCommand
        {
            get;
            set;
        }

        private void GoToMap()
        {
            var masterDetailPage = App.Current.MainPage as MasterDetailPage;
            if (masterDetailPage != null && !(
                GetCurrentPage() is MapView))
            {
                masterDetailPage.Detail.Navigation.PushAsync(new MapView());
            }
            masterDetailPage.IsPresented = false;
        }

        public ICommand SaveNewPointCommand
        {
            get;
            set;
        }

        private void SaveNewPoint()
        {
            MapPoints.Add(CurrentMapPoint);
            GoToPointList();
        }

        private Page GetCurrentPage() 
        {
            var masterDetailPage = App.Current.MainPage as MasterDetailPage;

            if (masterDetailPage != null)
            {
                int currentIndex = masterDetailPage.Navigation.NavigationStack.Count - 1;
                if(currentIndex < 0)
                {
                    return ((NavigationPage)masterDetailPage.Detail).CurrentPage;
                }
                return masterDetailPage.Navigation.NavigationStack[currentIndex];
            }
            return null;
        }

        #endregion
    }
}
