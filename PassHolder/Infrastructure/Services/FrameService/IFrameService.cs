using PassHolder.ViewModel;

namespace PassHolder.Infrastructure.Services.FrameService
{
    public interface IFrameService
    {
        public void ViewFrame(IViewModel viewModel, IFrame frame);
        public void HideFrame(IViewModel viewModel);
    }
}
