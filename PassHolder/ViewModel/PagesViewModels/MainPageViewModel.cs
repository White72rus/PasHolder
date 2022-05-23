using PassHolder.Infrastructure.Services.FrameService;

using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace PassHolder.ViewModel.PagesViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        private ObservableCollection<TailItemList> _panelItams = new ObservableCollection<TailItemList>();
        private double _baseFontSize = 20;
        private IFrameService _frameService;
        private IViewModel _viewModel;

        private Uri _addPage = new Uri($"../Pages/AddPage.xaml", UriKind.Relative);

        public MainPageViewModel()
        {
            _frameService = new FrameService();
            _viewModel = MainWindowViewModel.GetInstance();

            for (int i = 0; i < 5; i++)
            {
                _panelItams.Add(new TailItemList
                {
                    AppName = "MyApp_" + i,
                    AppLogin = "My_login_" + i,
                    AppPass = "My_pass_" + i,
                    AppUrl = "http://my_site_" + i,
                    //CommandCopyLogin = CopyToClipboardLogin,
                    //CommandCopyPass = CopyToClipboardPass,
                });
            }
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

        public ICommand AddNewTailCommand => RunCommand(() => { ShowAddNewTail(); });

        private void ShowAddNewTail()
        {
            _frameService.ViewFrame(_viewModel, new Frame { Name = "Add new tail", Uri = _addPage });
        }

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
