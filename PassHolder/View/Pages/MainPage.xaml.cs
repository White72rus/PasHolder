using PassHolder.ViewModel.PagesViewModels;

using System.Windows.Controls;

namespace PassHolder.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            MainPageViewModel viewModel = new MainPageViewModel();
            this.DataContext = viewModel;
        }
    }
}
