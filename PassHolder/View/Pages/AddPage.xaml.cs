using PassHolder.ViewModel.PagesViewModels;

using System.Windows.Controls;

namespace PassHolder.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddPage.xaml
    /// </summary>
    public partial class AddPage : Page
    {
        public AddPage()
        {
            InitializeComponent();
            AddPageViewModel viewModel = new AddPageViewModel();
            this.DataContext = viewModel;
        }
    }
}
