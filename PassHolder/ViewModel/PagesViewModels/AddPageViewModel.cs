using PassHolder.Infrastructure.Services.FrameService;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PassHolder.ViewModel.PagesViewModels
{
    public class AddPageViewModel : BaseViewModel
    {
        #region Private

        private IFrameService _frameService;
        private IViewModel _viewModel;

        private string _appName;
        private string _appLogin;
        private string _appPass;
        private string _appUri; 

        #endregion

        #region Public properties
        public string AppName { get => _appName; set => Set(ref _appName, value); }
        public string AppLogin { get => _appLogin; set => Set(ref _appLogin, value); }
        public string AppPass { get => _appPass; set => Set(ref _appPass, value); }
        public string AppUri { get => _appUri; set => Set(ref _appUri, value); } 
        #endregion

        public AddPageViewModel()
        {
            _frameService = new FrameService();
            _viewModel = MainWindowViewModel.GetInstance();
        }

        public ICommand OkCloseCommand => RunCommand(() => { SaveClosePage(); });

        private void SaveClosePage()
        {
            _frameService.HideFrame(_viewModel);
        }
    }
}
