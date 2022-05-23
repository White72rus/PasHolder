using System.Security;

namespace PassHolder.Infrastructure.Services.AuthService
{
    public interface ILoginResult
    {
        public SecureString Login { get; set; }
        public SecureString Password { get; set; }
    }
}
