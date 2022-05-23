using PassHolder.ViewModel.PagesViewModels;

using System.Windows.Controls;

namespace PassHolder.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для SettingsPage.xaml
    /// </summary>
    public partial class SettingsPage : Page
    {
        public SettingsPage()
        {
            InitializeComponent();
            SettingsPageViewModel viewModel = new SettingsPageViewModel();
            this.DataContext = viewModel;
        }
    }
}
