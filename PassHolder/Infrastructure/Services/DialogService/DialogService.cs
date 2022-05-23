using PassHolder.View.Windows;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassHolder.Infrastructure.Services.DialogService
{
    internal class DialogService
    {
        public static DialogResult MessageBox()
        {
            MessageBoxWindow messageBox = new MessageBoxWindow();
            messageBox.ShowDialog();
            return DialogResult.OK;
        }
    }

    internal enum DialogType
    {
        Qestion,
        Info,
        Warning,
        Error,
    }

    internal enum DialogResult
    {
        OK,
        Cancel,
        No,
        Yes,
    }
}
