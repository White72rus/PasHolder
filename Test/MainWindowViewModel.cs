using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Test
{
    public class MainWindowViewModel : BaseViewModel
    {
        private string _title = String.Empty;

        public string Title
        {
            get => _title;
            set => Set(ref _title, value);
        }

        public ICommand ToggleChekedCommand => RunCommand(() =>
        {

        });

        public ICommand MyCommand => RunCommand(() => {
            Title = "My title";
        });

        private static DelegateCommand RunCommand(Action action, bool canExec = true)
        {
            return new DelegateCommand(obj => { action(); }, obj => canExec);
        }
    }
}
