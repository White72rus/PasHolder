using PassHolder.ViewModel.ComponetsViewModel;

using System.Windows.Controls;

namespace PassHolder.Components
{
    /// <summary>
    /// Логика взаимодействия для TailItemLogPass.xaml
    /// </summary>
    public partial class TailItemLogPass : UserControl
    {
        public TailItemLogPass()
        {
            InitializeComponent();
            TailItemLogPassViewModel viewModel = new TailItemLogPassViewModel();
            this.DataContext = viewModel;
        }
    }
}
