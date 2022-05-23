using PassHolder.Infrastructure.Services.AuthService;
using PassHolder.Infrastructure;

using System.Runtime.CompilerServices;
using System.ComponentModel;
using System.Security;
using System;

namespace PassHolder.ViewModel
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        internal ILoginResult LoginResult { get; set; }

        protected void OnPropertyChanged(string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual bool Set<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
        {
            if (Equals(field, value))
                return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        /// <summary>
        /// Executing command without parameters
        /// </summary>
        /// <param name="action">Object for execute</param>
        /// <param name="canExec">Can execute param</param>
        /// <returns></returns>
        protected virtual DelegateCommand RunCommand(Action action, bool? canExec = null) =>
            new DelegateCommand(obj => { action(); }, obj => canExec);

        /// <summary>
        /// Executing command with parameters <br/>
        /// T - Type variable of parameter for command.
        /// </summary>
        /// <typeparam name="T">Parameter variable type</typeparam>
        /// <param name="action">Object for execute</param>
        /// <param name="canExec">Can execute param</param>
        /// <returns>DelegateCommand</returns>
        protected virtual DelegateCommand RunCommand<T>(Action<T> action, bool? canExec = null) =>
            new DelegateCommand(obj => { action((T)obj); }, obj => canExec);

        

        internal void CloseDialogWithResult(MainWindowViewModel viewModel, SecureString login, SecureString pass)
        {
            LoginResult = new LoginResult(login, pass);
            viewModel.Auth(LoginResult);
        }
    }
}
