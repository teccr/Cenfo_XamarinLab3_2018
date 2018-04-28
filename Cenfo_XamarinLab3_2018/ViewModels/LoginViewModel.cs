using System;
using System.Windows.Input;
using Cenfo_XamarinLab3_2018.Views;
using Xamarin.Forms;

namespace Cenfo_XamarinLab3_2018.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        #region Mockup

        private string _correctUser = "user";
        private string _correctPass = "user";

        #endregion

        #region Singleton Definition

        private static LoginViewModel instance = null;

        public static LoginViewModel GetInstance()
        {
            if (instance == null)
            {

                instance = new LoginViewModel();
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

        public LoginViewModel()
        {
            InitCommands();
            InitClass();
        }

        private void InitClass()
        {

        }

        private void InitCommands()
        {
            LoginCommand = new Command( Login );
        }

        #endregion

        #region Commands

        public ICommand LoginCommand
        {
            get;
            set;
        }

        private void Login()
        {
            if(string.IsNullOrEmpty(User) || string.IsNullOrEmpty( Password ) )
            {
                ShowError = true;
                ErrorMessage = "User and Password are required fields";
            }
            if(_correctUser == User.ToLower() && _correctPass == Password)
            {
                App.Current.MainPage = new MasterDetailView();
            }
            else
            {
                ShowError = true;
                ErrorMessage = "Incorrect credentials, please try again.";
            }
        }

        #endregion


        #region Properties

        private bool _showError;
        public bool ShowError
        {
            get
            {
                return _showError;
            }
            set
            {
                _showError = value;
                OnPropertyChanged("ShowError");
            }
        }

        private string _errorMessage;
        public string ErrorMessage
        {
            get
            {
                return _errorMessage;
            }
            set
            {
                _errorMessage = value;
                OnPropertyChanged("ErrorMessage");
            }
        }

        private string _password;
        public string Password {
            get {
                return _password;
            }
            set {
                _password = value;
                OnPropertyChanged("Password");
            }
        }

        private string _user;
        public string User
        {
            get
            {
                return _user;
            }
            set
            {
                _user = value;
                OnPropertyChanged("User");
            }
        }

        #endregion
    }
}
