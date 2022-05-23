using System.Runtime.InteropServices;
using PassHolder.View.Windows.Login;
using PassHolder.ViewModel.Login;
using PassHolder.DataBase;
using System.Diagnostics;
using System.Reflection;
using System.Security;
using System;

namespace PassHolder.Infrastructure.Services.AuthService
{
    internal class AuthService : IAuthService
    {
        #region Private

        private DataBase.DataBase _dataBase;

        #endregion

        #region Public

        public ILoginResult LoginResult { get; set; } 

        #endregion

        public AuthService()
        {
            _dataBase = new DataBase.DataBase();
        }

        void ʹ() { }

        /// <summary>
        /// Check on authorization.
        /// </summary>
        /// <param name="loginResult">Result object from UI</param>
        /// <returns></returns>
        bool IAuthService.Auth(ILoginResult loginResult)
        {
            LoginResult = loginResult;

            string t = $"{Assembly.GetExecutingAssembly().GetName().Name}" +
                $"{ Environment.UserName}{loginResult.Login._()}";

            if (_dataBase.GetDataForAuth().Equals(Utils.GetHash(ref t)))
            {
#if DEBUG
                Debug.WriteLine("Auth: true");
#endif
                // TO DO
                return true;
            }
#if DEBUG
            Debug.WriteLine("Auth: false");
#endif
            // TO DO
            return false;
        }

        bool IAuthService.IsFileExist()
        {
            throw new NotImplementedException();
        }

        bool IAuthService.Initialize()
        {
            LoginWindow window = LoginWindow.GetInstance();

            if (!DataFiles.IsDataFileExists())
            {
                NewAccountViewModel newAccountViewModel = new NewAccountViewModel();
                window.DataContext = newAccountViewModel;
                //if(!window.IsLoaded)
                window.Show();
                return true;
            }

            LoginViewModel loginViewModel = new LoginViewModel();
            window.DataContext = loginViewModel;
            window.Show();
            ILoginResult loginResult;


            return true;
        }

        void IAuthService.OpenLoginDialog()
        {
            LoginWindow window = LoginWindow.GetInstance();

            if (!DataFiles.IsDataFileExists())
            {
                NewAccountViewModel newAccountViewModel = new NewAccountViewModel();
                window.DataContext = newAccountViewModel;
                //if(!window.IsLoaded)
                window.Show();
                LoginResult = newAccountViewModel.LoginResult;
            }

            LoginViewModel loginViewModel = new LoginViewModel();
            window.DataContext = loginViewModel;
            window.Show();
            //ILoginResult loginResult;


            LoginResult = loginViewModel.LoginResult;
        }

        
    }

    /// <summary>
    /// Utility class for auth mechanism
    /// </summary>
    internal static class AuthUtils {
        public static string _(this SecureString secureString)
        {
            if (secureString == null)
                throw new ArgumentNullException(nameof(secureString));
            IntPtr unmanagedString = IntPtr.Zero;
            try
            {
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(secureString);
                return Marshal.PtrToStringUni(unmanagedString);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
        }
    }

    internal enum AuthResult
    {
        FileNotFound,
        BadLogin,
        Ok,
    }
}
