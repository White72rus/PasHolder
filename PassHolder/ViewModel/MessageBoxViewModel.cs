using PassHolder.Infrastructure;
using PassHolder.View.Windows;

using System;
using System.Windows.Input;

namespace PassHolder.ViewModel
{
    internal class MessageBoxViewModel : BaseViewModel
    {
        #region Private properties

        private static MessageBoxViewModel _instance;
        private string _title = string.Empty;
        private string _message = string.Empty;
        private string _type;

        #endregion

        #region Public properties
        internal Action? HidenAction { get; set; }
        internal Action? ShowAction { get; set; }
        internal Action? CloseAction { get; set; }

        public string Title
        {
            get => _title;
            private set => Set(ref _title, value);
        }

        public string Message
        {
            get => _message;
            private set => Set(ref _message, value);
        }

        public string Type
        {
            get => _type;
            private set => Set(ref _type, value);
        }

        #endregion

        public MessageBoxViewModel()
        {

        }

        #region Commands

        public ICommand OkCommand => RunCommand(() =>
        {
            //HidenAction?.Invoke();
            Message = "Cheng";
        });

        public ICommand CancelCommand => RunCommand(() =>
        {

        });

        #endregion

        public static MessageBoxViewModel GetInstance()
        {
            if (_instance == null)
                _instance = new MessageBoxViewModel();
            return _instance;
        }



        #region Methods

        public void Show(string message)
        {
            Message = message;
            MessageBoxWindow.GetInstance();
            ShowAction?.Invoke();
        }

        public void Show(string message, string title)
        {
            Title = title;
            Show(message);
        }

        #endregion
    }
}
