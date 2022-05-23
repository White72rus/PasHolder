using PassHolder.Infrastructure.Services.FrameService;

using System;
using System.Windows.Input;

namespace PassHolder.ViewModel.PagesViewModels
{
    public class SettingsPageViewModel : BaseViewModel
    {
        private IFrameService _frameService;
        private IViewModel _viewModel;

        public SettingsPageViewModel()
        {
            _viewModel = MainWindowViewModel.GetInstance();
            _frameService = new FrameService();
        }

        public ICommand OkCommand => RunCommand(() => { 
            _frameService.HideFrame(_viewModel); 
        });

        private void ClosePage()
        {
            MainWindowViewModel mainWindow = MainWindowViewModel.GetInstance();
            mainWindow.ViewMainPage();
        }
    }
}
