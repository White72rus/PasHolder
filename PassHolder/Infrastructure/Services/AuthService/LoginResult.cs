using System.Security;

namespace PassHolder.Infrastructure.Services.AuthService
{
    public class LoginResult : ILoginResult
    {
        public SecureString Login { get; set; }
        public SecureString Password { get; set; }

        public LoginResult() { }
        public LoginResult(SecureString login, SecureString pass)
        {
            Login = login;
            Password = pass;
        }
    }
}
