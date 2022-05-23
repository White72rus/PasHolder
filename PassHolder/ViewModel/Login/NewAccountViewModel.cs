using System;
using System.Windows.Input;

namespace PassHolder.ViewModel.Login
{
    public class NewAccountViewModel : BaseViewModel
    {
        private const string _message = "Not found any account. Pres button 'Add New' for create new account.";

        public Action CloseAction { get; set; }

        public string Message { get => _message; }

        public ICommand CloseCommand => RunCommand(() =>
        {
            CloseAction?.Invoke();
        });

        public ICommand LoginCommand => RunCommand(() => { });
    }
}
