using System;
using System.Windows;
using System.Windows.Input;
using PassHolder.Infrastructure;
using System.Collections.ObjectModel;
using PassHolder.Infrastructure.Services.AuthService;
using PassHolder.Infrastructure.Services.FrameService;

namespace PassHolder.ViewModel
{
    public class MainWindowViewModel : BaseViewModel, IViewModel
    {
        #region Private

        private ObservableCollection<TailItemList> _panelItams = new ObservableCollection<TailItemList>();
        private static MainWindowViewModel _instance;
        private readonly DataBase.DataBase _dbContext;
        private static string _basePagesPath = "../Pages/";
        private IFrameService _frameService;
        private IAuthService _authService;
        private ILoginResult _loginResult;
        private Uri _uri;
        private string _title;

        private static readonly DelegateCommand? _delegateCommand;
        private Visibility _visible;
        private double _baseFontSize = 20;
        private string _login;


        private Uri _mainPage = new Uri($"{_basePagesPath}MainPage.xaml", UriKind.Relative);
        private Uri _settingsPage = new Uri($"{_basePagesPath}SettingsPage.xaml", UriKind.Relative);
        private Uri _addPage = new Uri($"{_basePagesPath}AddPage.xaml", UriKind.Relative);

        private readonly string _appName = "PassHolder";
        #endregion

        #region Public

        internal Action? HidenAction { get; set; }
        internal Action? ShowAction { get; set; }
        internal Action? CloseAction { get; set; }
        internal Action? MinimizedAction { get; set; }
        internal Action? DragAction { get; set; }

        #endregion

        public MainWindowViewModel()
        {
            
            _frameService = new FrameService();
            _authService = new AuthService();
            _dbContext = new DataBase.DataBase();

            ViewMainPage();

            for (int i = 0; i < 5; i++)
            {
                _panelItams.Add(new TailItemList
                {
                    AppName = "MyApp_" + i,
                    AppLogin = "My_login_" + i,
                    AppPass = "My_pass_" + i,
                    AppUrl = "http://my_site_" + i,
                    CommandCopyLogin = CopyToClipboardLogin,
                    CommandCopyPass = CopyToClipboardPass,
                });
            }
        }

        internal static MainWindowViewModel GetInstance()
        {
            if (_instance == null)
                _instance = new MainWindowViewModel();
            return _instance;
        }

        #region Properties

        //internal string Login { get; set; }
        public Uri PagesSource
        {
            get => _uri;
            set => Set(ref _uri, value);
        }

        public string AppName => _appName;

        public string Title
        {
            get => _title;
            set => Set(ref _title, value);
        }

        public string Login
        {
            get => _login;
            set => Set(ref _login, value, nameof(Login));
        }

        public double BaseFontSize
        {
            get => _baseFontSize;
            set => Set(ref _baseFontSize, value);
        }

        public ObservableCollection<TailItemList> PanelItam
        {
            get => _panelItams;
            private set => Set(ref _panelItams, value);
        }

        public Visibility Visible
        {
            get => _visible;
            private set => Set(ref _visible, value);
        }

        #endregion

        #region Commands

        /// <summary>
        /// Test command
        /// </summary>
        public ICommand Run => RunCommand(() => { HidenAction?.Invoke(); });

        public ICommand AddNewTailCommand => RunCommand(() => { MessageBox.Show(Login); });

        public ICommand DragWindow => RunCommand(() => { DragAction?.Invoke(); });

        public ICommand CloseApp => RunCommand(() => { CloseAction?.Invoke(); });

        public ICommand MinimizedApp => RunCommand(() =>  { MinimizedAction?.Invoke(); });

        public ICommand ActivPegeSettingsCommand => RunCommand(() => { ViewSettingsPage(); });

        public ICommand ShowMenuBtnCommand => RunCommand(() =>
        {
            Login = "My Login";
            PanelItam.Add(new TailItemList
            {
                AppName = "New App Name",
                AppLogin = Login,
                AppPass = "New App Pass",
                AppUrl = "http://new_url",
            });
        });

        public ICommand ListItemClick => RunCommand<int>((o) => { MessageBox.Show("Index: " + o.ToString()); });

        public ICommand CopyToClipboardLogin => RunCommand<string>((o) =>
        {
            foreach (var item in _panelItams)
            {
                if (item.AppName == o)
                {
                    Clipboard.Clear();
                    Clipboard.SetText(item.AppLogin);
                }
            }
        });

        public ICommand CopyToClipboardPass => RunCommand<string>((o) =>
        {
            foreach (var item in _panelItams)
            {
                if (item.AppName == o)
                {
                    Clipboard.Clear();
                    Clipboard.SetText(item.AppPass);
                }
            }
        });

        public ICommand EventLoadedCommand => RunCommand(() => {
            HidenWindow();
            Initialize();
        });

        #endregion

        internal void Auth(ILoginResult loginResult)
        {
            //if (login == _dbContext.GetDataForAuth())
            //    return true;
            //return false;
            _loginResult = loginResult;
        }

        internal void ViewMainPage()
        {
            _frameService.ViewFrame(this, new Frame { Name = _appName, Uri = _mainPage});
            //PagesSource = _mainPage;
        }

        internal void ViewSettingsPage()
        {
            _frameService.ViewFrame(this, new Frame { Name = "Settings", Uri = _settingsPage });
            //PagesSource = _mainPage;
        }

        #region Method

        private void HidenWindow()
        {
            HidenAction?.Invoke();
        }

        private void Initialize()
        {
            _authService.OpenLoginDialog();
        }

        #endregion

    }

    public class TailItemList
    {
        public string AppName { get; set; }
        public string AppLogin { get; set; }
        public string AppPass { get; set; }
        public string? AppUrl { get; set; }
        public ICommand? CommandCopyLogin { get; set; }
        public ICommand? CommandCopyPass { get; set; }
    }
}
