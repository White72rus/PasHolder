using PassHolder.ViewModel;

using System;

namespace PassHolder.Infrastructure.Services.FrameService
{
    public class FrameService : IFrameService
    {
        public void HideFrame(IViewModel viewModel)
        {
            viewModel.PagesSource = new Uri($"../Pages/MainPage.xaml", UriKind.Relative);
            viewModel.Title = viewModel.AppName;
        }

        public void ViewFrame(IViewModel viewModel, IFrame frame)
        {
            viewModel.PagesSource = frame.Uri;
            viewModel.Title = frame.Name;
        }
    }
}
