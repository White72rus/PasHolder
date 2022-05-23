namespace PassHolder.Infrastructure.Services.AuthService
{
    internal interface IAuthService
    {
        internal ILoginResult LoginResult { get; set; }
        internal bool Auth(ILoginResult loginResult);
        internal bool IsFileExist();
        internal bool Initialize();
        internal void OpenLoginDialog();
    }
}